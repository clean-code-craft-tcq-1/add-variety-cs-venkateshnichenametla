﻿using System;
namespace TypewiseAlert
{
    public class ControllerAlert : IAlert
    {
        public void PublishAlert(string breachType)
        {
            Console.WriteLine("{0}\n", breachType);
        }
    }
}