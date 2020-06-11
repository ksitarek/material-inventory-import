using System;

namespace MaterialInventoryImport
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine() => Console.ReadLine();

        public void WriteLine(string val = "") => Console.WriteLine(val);
    }
}