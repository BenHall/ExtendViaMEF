using System;
using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled
{
    [Export(typeof(ILogger))]
    [Export("Internal", typeof(ILogger))]
    public class Logger : ILogger
    {
        public Logger()
        {
            Console.WriteLine("Created");
        }
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}