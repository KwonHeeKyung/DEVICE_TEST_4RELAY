
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

volatile unsigned char RX_BUF[1], Relay[2], Test, Case;

void setup() {
	
	cli();

	//UART
	// 8MHz 38400
	//UBRRL = 12;
	UBRRL = 51; // 9600 bps

	DDRB = (0 << PB2) | (1 << PB1) | (1 << PB0); // PB2 : 자석2, PB1: 전원제어2 , PB0: 전원제어1
	DDRC = (1 << PC3) | (1 << PC2) | (0 << PC0); // PC3: 데드볼트2, PC2: 데드볼트1, PC0: 자석1
	DDRD = (1 << PD1) | (0 << PD0); //UART
	
	PORTC = (1 << PC0); // 자석1 풀업 저항
	PORTB = (1 << PB2); // 자석2 풀업 저항

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
	else if(RX_BUF[0] == '3') // 2번문 열기
	{
		if(Test == 1)
		{
			cbi(PORTC,3);
		}
		else
		{
			cbi(PORTC,3);
			Relay[1] = 0;
			_delay_ms(5000);
		}
	}
	else if(RX_BUF[0] == '4') // 1번문 닫기
	{	
		sbi(PORTC,2);
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

void tillend()
{

	printf("2");
	Relay[0] = 2;
	Relay[1] = 2;

}

void loop(){

	if(Test == 0)
	{
		if(Relay[0] == 0)
		{
			if(!(PINC&0x01))
			{
				printf("0");
				sbi(PORTC,2);
				Relay[0] = 1;
			}
		}

		if(Relay[1] == 0)
		{
			if(!(PINB&0x04))
			{
				printf("0");
				sbi(PORTC,3);
				Relay[1] = 1;
			}
		}

		if(Relay[0] == 1)
		{
			if(PINC&0x01)
			{
				_delay_ms(5000);
				tillend();
			}
		}
		if(Relay[1] == 1)
		{
			if(PINB&0x04)
			{
				_delay_ms(5000);
				tillend();
			}
		}
		
	}
	else if(Test == 1) // 테스트모드
	{
		
		if(((PINC&0x01) != 0x01) && ((PINB&0x04) != 0x04))
		{
			printf("c,c");
		
		}
		else if(((PINC&0x01) != 0x01) &&((PINB&0x04) == 0x04))
		{
			printf("c,o");
		
		}
		else if(((PINC&0x01) == 0x01) && ((PINB&0x04) != 0x04))
		{
			printf("o,c");
		
		}
		else if(((PINC&0x01) == 0x01) && ((PINB&0x04) == 0x04))
		{
			printf("o,o");
		
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

