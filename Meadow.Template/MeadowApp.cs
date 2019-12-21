﻿using System;
using System.Collections.Generic;
using System.Threading;
using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Leds;

namespace $safeprojectname$
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        RgbPwmLed rgbPwmLed;
        const int _pulseDuration = 3000;

        public MeadowApp()
        {
            rgbPwmLed = new RgbPwmLed(Device,
                       Device.Pins.OnboardLedRed,
                       Device.Pins.OnboardLedGreen,
                       Device.Pins.OnboardLedBlue);

            PulseRgbPwmLed();
        }

        protected void PulseRgbPwmLed()
        {
            while (true)
            {
                Pulse(Color.Red);
                Pulse(Color.Green);
                Pulse(Color.Blue);
            }
        }

        protected void Pulse(Color color)
        {
            rgbPwmLed.StartPulse(color);
            Console.WriteLine($"Pulsing {color}");
            Thread.Sleep(_pulseDuration);
            rgbPwmLed.Stop();
        }
    }
}
