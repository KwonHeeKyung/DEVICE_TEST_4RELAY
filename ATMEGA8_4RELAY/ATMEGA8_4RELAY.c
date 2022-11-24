
#define F_CPU  8000000    // 8MHz processor

#include <avr\io.h>
#include <avr\interrupt.h>
#include <util\delay.h>
#include <stdio.h>
#include <avr/sfr_defs.h>
#include <string.h>

#define cbi(sfr,bit) (_SFR_BYTE(sfr) &= ~_BV(bit))	//clear bit
#define sbi(sfr,bit) (_SFR_BYTE(sfr) |= _BV(bit))	//set bit

void UART2PC(void);
static int USART_putchar(char c, FILE *stream);
static FILE device = FDEV_SETUP_STREAM(USART_putchar, NULL, _FDEV_SETUP_WRITE);

volatile unsigned char RX_BUF[1], Relay[2], Test;

void setup() {
	
	cli();

	//UART
	// 8MHz 38400
	UBRRL = 12;

	DDRB = (1 << PB1) | (1 << PB0); // PB1: 전원제어2 , PB0: 전원제어1
	DDRC = (1 << PC3) | (1 << PC2) | (0 << PC1) | (0 << PC0); // PC3: 데드볼트2, PC2: 데드볼트1, PC1: 자석2 , PC0: 자석1
	DDRD = (1 << PD1) | (0 << PD0); //UART
	
	PORTC = (1 << PC1) | (1 << PC0); // 자석 풀업 저항

	UCSRB = (1 << RXCIE) | (1 << RXEN) | (1 << TXEN);

	Relay[0] = 1;
	Relay[1] = 1;

	Test = 0;

	//전원 High
	sbi(PORTB, 0);
	sbi(PORTB, 1);

	//데드볼트 High
	sbi(PORTC, 2);
	sbi(PORTC, 3);

	stdout = &device;

	sei();

}

ISR(SIG_UART_RECV)
{
	cli();

	while((UCSRA &(1<<RXC)) == 0);
	
	RX_BUF[0] = UDR;

	if(RX_BUF[0] == '1') // 1번문 열기
	{
		if(Test == 1)
		{
			cbi(PORTC,2);
		}
		else
		{
			cbi(PORTC,2);
			Relay[0] = 0;
			_delay_ms(5000);
		}
	}
	else if(RX_BUF[0] == '3') // 1번문 닫기
	{
		sbi(PORTC,2);
	}
	else if(RX_BUF[0] == '4') // 2번문 열기
	{
		if(Test == 1)
		{
			sbi(PORTC, 3);
		}
		else
		{
			cbi(PORTC,3);
			Relay[1] = 0;
			_delay_ms(5000);
		}
	}
	else if(RX_BUF[0] == '5') // 2번문 닫기
	{
		sbi(PORTC,3);
	}
	else if(RX_BUF[0] == '6') // 1번 전원 제어 (NC)
	{
		sbi(PORTB,0);
	}
	else if(RX_BUF[0] == '7') // 1번 전원 제어 (NO)
	{
		cbi(PORTB,0);
	}
	else if(RX_BUF[0] == '8') // 2번 전원 제어 (NC)
	{
		sbi(PORTB,1);
	}
	else if(RX_BUF[0] == '9') // 2번 전원 제어 (NO)
	{
		cbi(PORTB,1);
	}
	else if(RX_BUF[0] == 'T') 
	{
		Test = 1;  // set test mode
	}
	else if(RX_BUF[0] == 'F') 
	{
		Test = 0;  // end test mode
	}

	sei();
}

void tillend(int x, int n)
{
	if(n==2){
		printf("R1_2");
		Relay[0] = 2;
	}
	else if(n==3)
	{
		printf("R2_2");
		Relay[1] = 2;
	}
	/*
	int a = 0;
	do{
		cbi(PORTB,n);
		_delay_ms(1500);
		sbi(PORTB,n);
		_delay_ms(1500);
		a++;
	}while(a <= x);
	
	//exit(0);
	if(n==2){
		printf("R1_2");
		Relay[0] = 2;
	}
	else if(n==3)
	{
		printf("R2_2");
		Relay[1] = 2;
	}
	*/

}

void loop(){

	if(Test == 0)
	{
		//1번문 제어
		if(Relay[0] == 0) //자석 가까운데 문 열려있음
		{
			if(!(PINC&0x04))
			{
				printf("R1_0");
			
				sbi(PORTC,2);
				Relay[0] = 1;
			}
		}
		else if(Relay[0] == 1) //문닫혀있는데 자석 멀음
		{
			
			if(PINC&0x04)
			{
				_delay_ms(5000);
				tillend(3, 2);
			}
		}

		//2번문 제어
		if(Relay[1] == 0) //자석 가까운데 문 열려있음
		{
			if(!(PINC&0x08))
			{
				printf("R2_0");
			
				sbi(PORTC,3);
				Relay[1] = 1;
			}
		}
		else if(Relay[1] == 1) //문닫혀있는데 자석 멀음
		{
			
			if(PINC&0x08)
			{
				_delay_ms(5000);
				tillend(3, 3);
			}
		}
	}
	else if(Test == 1)
	{
		//자석 1
		if(!(PINC&0x01)) 
		{
			printf("c");
		}

		if(PINC&0x01)
		{
			printf("o");
		}

		//자석 2
		if(!(PINC&0x02)) 
		{
			printf(",c");
		}

		if(PINC&0x02)
		{
			printf(",o");
		}

	}
}

int main(void)
{
	
    setup();
	
    while (1) 
    {
		loop();
		_delay_ms(1000);
    }
	
	return 0;
}

static int USART_putchar(char c, FILE *stream)
{
	if(c == '\n')
	{   loop_until_bit_is_set(UCSRA,UDRE);
		UDR = 0x0D;
		loop_until_bit_is_set(UCSRA,UDRE);
		UDR = 0x0A;
	}
	else
	{  loop_until_bit_is_set(UCSRA,UDRE);
		UDR = c;
	}
	return 0;

}
