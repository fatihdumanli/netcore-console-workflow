using System;

namespace ProcessFlow.IO
{
    public class ConsoleInput : IInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}