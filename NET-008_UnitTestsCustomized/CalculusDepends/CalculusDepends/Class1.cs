using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusDepends
{
    public class Calculator {
        private static int memory;

        public void SetMemory(int x) {
            memory += x;
        }

        public void ClearMemory() {
        }

        public int Sum(int x, int y) {
            checked {
                return x + y;
            }
        }

        public int Sub(int x, int y) {
            checked {
                return x - y;
            }
        }

        public int GetMemory() {
            return memory;
        }
    }
}
