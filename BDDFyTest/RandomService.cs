using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDFyTest
{
    public class RandomService
    {
        private int iterations { get; set; }
        private bool shouldRun { get; set; }

        public RandomService(int iterations, bool shouldRun)
        {
            this.iterations = iterations;
            this.shouldRun = shouldRun;
        }

        public bool PrintMessage (string message)
        {
            if(shouldRun && iterations >= 1)
            {
                var count = 1;
                do
                {
                    Console.WriteLine("I've already done ");
                    count++;
                }
                while (count <= iterations);

                return true;
            }

            return false;
        }
    }
}
