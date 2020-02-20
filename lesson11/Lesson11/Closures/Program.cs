using System;
using System.Collections.Generic;
using System.Linq;

namespace Closures
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "Initial state";

            Action action = delegate ()
            {
                Console.WriteLine(s);
                s = "Action. Modified variable.";
            };

            action();
            Console.WriteLine(s);

            var actions = new List<Func<int>>();

            for (int i = 0; i < 4; i++)
            {
                var tmp = i;
                actions.Add(() => tmp);
            }

            foreach (var func in actions)
            {
                Console.WriteLine(func());
            }
        }
    }
}
