using System;
using ProcessFlow.Renderer;

namespace Renderer 
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}