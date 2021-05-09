/******************************************************************************
 * File: Plotting temp.c
 * Copyright (C) 2017 ALHASAN ALKHATIB
 *
 * date:   12, 2017
 * Author: ALHASAN ALKHATIB
 *
 * Description: this C code is used to read and process an analog signal(Tempreture value, but can be another analog signal)
 *              from PE3 and then Sending it to PC using Serial port-UART through PA0 PA1
 *              the delay between 2 Measurement process(Sampling time) can be controlled from PC
 *
 *              (main file)
 *****************************************************************************/
#include <stdint.h>
#include <stdbool.h>
#include "driverlib/sysctl.h"
#include "driverlib/sysctl.h"
#include "HasUARTTemp.h"



int main()
{
	 SysCtlClockSet(SYSCTL_SYSDIV_4 | SYSCTL_USE_PLL | SYSCTL_XTAL_16MHZ| SYSCTL_OSC_MAIN);
	 has_TempConfig();
	 while(1)
	 {

	 }
}

