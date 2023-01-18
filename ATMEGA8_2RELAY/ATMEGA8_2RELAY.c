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

volatile unsigned char RX_BUF[1], Relay, Test, p;

void setup() {
	
	cli();

	//UART
	// 8MHz 38400
	//UBRRL = 12;
	UBRRL = 51; // 9600 bps

	DDRB = (1 << PB0); // PB0: 전원제어
	DDRC = (1 << PC2) | (0 << PC0); // PC2: 데드볼트,  PC0: 자석
	DDRD = (1 << PD1) | (0 << PD0); //UART
	
	PORTC = (1 << PC0); // 자석 풀업 저항

	UCSRB = (1 << RXCIE) | (1 << RXEN) | (1 << TXEN);

	Relay = 1;
	Test = 0;
	p=0;
	
	sbi(PORTB, 0);
	sbi(PORTC, 2);

	//상태체크 LED
	sbi(PORTC, 5);

	stdout = &device;

	sei();

}

ISR(SIG_UART_RECV)
{
	cli();

	int test, command;

	while((UCSRA &(1<<RXC)) == 0);
	
	RX_BUF[0] = UDR;

	if(RX_BUF[0] == '1')
	{
		if(Test == 1)
		{
			cbi(PORTC,2); //Deadbolt ON
		}
		else
		{
			cbi(PORTC,2); //Deadbolt ON
			Relay = 0;
			_delay_ms(5000);
		}
	}
	else if(RX_BUF[0] == '4')
	{
		sbi(PORTC,2); //Deadbolt OFF
	}
	else if(RX_BUF[0] == '6')
	{
		sbi(PORTB,0); //Board ON
	}
	else if(RX_BUF[0] == '7') 
	{
		cbi(PORTB,0); //Board OFF
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

void tillend(int x)
{
	int a = 0;
	do{
		cbi(PORTC,2);
		_delay_ms(1500);
		sbi(PORTC,2);
		_delay_ms(1500);
		a++;
	}while(a <= x);
	//printf("2");
	//Relay = 2;
}

void loop(){

	if(Test == 0)
	{
		if(Relay == 0) //자석 가까운데 문 열려있음
		{
			if(!(PINC&0x01))
			{
				printf("0");
			
				sbi(PORTC,2);
				Relay = 1;
			}
		}
		else if(Relay == 1) //문닫혀있는데 자석 멀음
		{
			
			if(PINC&0x01)
			{
				tillend(3);
				p=2;
			}
		}

		if((p==2) && (PINC&0x01) && (Relay==1))
		{
			printf("2");
		}
		if((p==2) && (!(PINC&0x01)) && (Relay==1))
		{
			printf("r");
			p=0;
		}
	}
	else if(Test == 1)
	{
		if(!(PINC&0x01))
		{
			printf("c");
		}

		if(PINC&0x01)
		{
			printf("o");
		}
	}
}

int main(void)
{
	//프로그램 업데이트되면 LED ON, OFF
	sbi(PORTC, 4);
	_delay_ms(300);
	cbi(PORTC, 4);

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


