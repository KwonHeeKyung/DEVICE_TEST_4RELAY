
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

	DDRB = (1 << PB1) | (1 << PB0); // PB1: ��������2 , PB0: ��������1
	DDRC = (1 << PC3) | (1 << PC2) | (0 << PC1) | (0 << PC0); // PC3: ���庼Ʈ2, PC2: ���庼Ʈ1, PC1: �ڼ�2 , PC0: �ڼ�1
	DDRD = (1 << PD1) | (0 << PD0); //UART
	
	PORTC = (1 << PC1) | (1 << PC0); // �ڼ� Ǯ�� ����

	UCSRB = (1 << RXCIE) | (1 << RXEN) | (1 << TXEN);

	Relay[0] = 1;
	Relay[1] = 1;

	Test = 0;

	//���� High
	sbi(PORTB, 0);
	sbi(PORTB, 1);

	//���庼Ʈ High
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

	if(RX_BUF[0] == '1') // 1���� ����
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
	else if(RX_BUF[0] == '3') // 1���� �ݱ�
	{
		sbi(PORTC,2);
	}
	else if(RX_BUF[0] == '4') // 2���� ����
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
	else if(RX_BUF[0] == '5') // 2���� �ݱ�
	{
		sbi(PORTC,3);
	}
	else if(RX_BUF[0] == '6') // 1�� ���� ���� (NC)
	{
		sbi(PORTB,0);
	}
	else if(RX_BUF[0] == '7') // 1�� ���� ���� (NO)
	{
		cbi(PORTB,0);
	}
	else if(RX_BUF[0] == '8') // 2�� ���� ���� (NC)
	{
		sbi(PORTB,1);
	}
	else if(RX_BUF[0] == '9') // 2�� ���� ���� (NO)
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
		//1���� ����
		if(Relay[0] == 0) //�ڼ� ���� �� ��������
		{
			if(!(PINC&0x04))
			{
				printf("R1_0");
			
				sbi(PORTC,2);
				Relay[0] = 1;
			}
		}
		else if(Relay[0] == 1) //�������ִµ� �ڼ� ����
		{
			
			if(PINC&0x04)
			{
				_delay_ms(5000);
				tillend(3, 2);
			}
		}

		//2���� ����
		if(Relay[1] == 0) //�ڼ� ���� �� ��������
		{
			if(!(PINC&0x08))
			{
				printf("R2_0");
			
				sbi(PORTC,3);
				Relay[1] = 1;
			}
		}
		else if(Relay[1] == 1) //�������ִµ� �ڼ� ����
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
		//�ڼ� 1
		if(!(PINC&0x01)) 
		{
			printf("c");
		}

		if(PINC&0x01)
		{
			printf("o");
		}

		//�ڼ� 2
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
