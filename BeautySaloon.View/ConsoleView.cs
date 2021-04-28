using System;
using System.Collections.Generic;

namespace BeautySaloon.View
{
    public class ConsoleView : Interfaces.IView
    {
        private string toPrint;
        private Controllers.Interfaces.IController controller;
        private void Commands()
        {
            Console.WriteLine("0 to list products;");
            Console.WriteLine("1 to check products;");
            Console.WriteLine("2 to list products in the bank;");
            Console.WriteLine("3 to add all needed products;");
            Console.WriteLine("4 to exit;");
            Console.WriteLine("=====");
        }
        private void Clear()
        {
            Console.Clear();
        }
        private void Print()
        {
            Console.WriteLine(toPrint);
        }
        public ConsoleView(Controllers.Interfaces.IController controller)
        {
            this.controller = controller;
            toPrint = "";
        }
        public void Update()
        {
            Clear();
            Commands();
            Print();

            string line;

            line = Console.ReadLine();
            toPrint = controller.Input(line);

            Update();
        }
    }
}
