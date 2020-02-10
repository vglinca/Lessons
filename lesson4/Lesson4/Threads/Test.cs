using System;
using System.Collections.Generic;
using System.Text;

namespace Threads {
    class Test {
        public static int _num;

        static Test() {
            _num = 10;
            Console.WriteLine("First time here.");
        }
    }
}
