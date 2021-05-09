/******************************************************************************
 * File: HasUARTTemp.c
 * Copyright (C) 2017 ALHASAN ALKHATIB
 *
 * date:   12, 2017
 * Author: ALHASAN ALKHATIB
 *
 * Description: this C code is used to read and process an analog signal(Tempreture value, but can be another analog signal)
 *              from PE3 and then Sending it to PC using Serial port-UART through PA0 PA1
 *              the delay between 2 Measurement process(Sampling time) can be controlled from PC
 *
 *              (Source file)
 *****************************************************************************/
#include <stdint.h>
#include <stdbool.h>
#include "inc/hw_types.h"
#include "inc/hw_memmap.h"
#include "driverlib/sysctl.h"
#include "driverlib/gpio.h"
#include "inc/hw_gpio.h"
#include "driverlib/interrupt.h"
#include "inc/hw_ints.h"
#include "driverlib/adc.h"
#include "driverlib/pin_map.h"
#include "driverlib/sysctl.h"
#include "driverlib/uart.h"
#include "HasUARTTemp.h"


uint8_t delay=10;

void has_TempConfig()
{

     	SysCtlPeripheralEnable(SYSCTL_PERIPH_ADC0);
		SysCtlPeripheralReset(SYSCTL_PERIPH_ADC0);
		SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOE);

		ADCSequenceDisable(ADC0_BASE, 1);

		ADCSequenceConfigure(ADC0_BASE, 1, ADC_TRIGGER_PROCESSOR, 0);

		ADCSequenceStepConfigure(ADC0_BASE, 1, 0, ADC_CTL_CH0);
		ADCSequenceStepConfigure(ADC0_BASE, 1, 1, ADC_CTL_CH0);
		ADCSequenceStepConfigure(ADC0_BASE, 1, 2, ADC_CTL_CH0);
		ADCSequenceStepConfigure(ADC0_BASE,1,3,ADC_CTL_CH0|ADC_CTL_IE|ADC_CTL_END);

		GPIOPinTypeADC(GPIO_PORTE_BASE,GPIO_PIN_3);
		ADCIntRegister(ADC0_BASE, 1,INTTemp);
		//ADCIntClear(ADC0_BASE,1);
		ADCIntEnable(ADC0_BASE,1);
		ADCSequenceEnable(ADC0_BASE, 1);


	            SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOF);
			    GPIOPinTypeGPIOOutput(GPIO_PORTF_BASE, GPIO_PIN_1);

				SysCtlPeripheralEnable(SYSCTL_PERIPH_UART0);//1
			    SysCtlPeripheralEnable(SYSCTL_PERIPH_GPIOA);//2

			    GPIOPinConfigure(0x00000001);//3
			    GPIOPinConfigure(0x00000401);//4
			    GPIOPinTypeUART(GPIO_PORTA_BASE, GPIO_PIN_0 | GPIO_PIN_1);//5

			    UARTConfigSetExpClk(UART0_BASE, SysCtlClockGet(), 115200,(UART_CONFIG_WLEN_8 | UART_CONFIG_STOP_ONE | UART_CONFIG_PAR_NONE));//6

			    IntEnable(INT_ADC0SS1_TM4C123);
			    		IntMasterEnable();
			    ADCProcessorTrigger(ADC0_BASE, 1);

}

void INTTemp()
{
	             uint8_t data=0;
                 uint32_t TempMeasure[4];
	    volatile uint32_t TempAvg;
	    volatile float TempC;
	    volatile uint8_t digit[3];
	             uint32_t TempCint;
	 	ADCIntClear(ADC0_BASE, 1);
	 	ADCSequenceDataGet(ADC0_BASE, 1, TempMeasure);
	 	TempAvg = (TempMeasure[0] + TempMeasure[1] + TempMeasure[2] + TempMeasure[3] + 2)/4;
	 	TempC = (TempAvg*805.66)/10000;//her 10 mv 1 C **** 3300/4096=0.80566--->TempC = ((TempAvg*0.80566)/10) --->=((TempAvg*805.66)/10000)
	 	TempCint=TempC*10; //virgulden sonra bir basamak alalim
	 	digit[0]=(TempCint)/100;//
	 	digit[1]=(TempCint/10)%10;
	 	digit[2]=(TempCint)%10;

                   UARTCharPut(UART0_BASE,' ');
                   UARTCharPut(UART0_BASE,(digit[0]+48));
                   UARTCharPut(UART0_BASE,(digit[1]+48));
                   //"."
                   UARTCharPut(UART0_BASE,(digit[2]+48));
                   UARTCharPut(UART0_BASE,'E');

          if(UARTCharsAvail(UART0_BASE)){
        	   data=UARTCharGet(UART0_BASE);
    		   if(data=='N'){
    			   if(delay<100){delay++;}
    		   }
    		   else if(data=='P'){
    			   if(delay>2){delay--;}
    		   }
    	  }
	      SysCtlDelay(SysCtlClockGet()/delay);

	ADCProcessorTrigger(ADC0_BASE, 1);

}

