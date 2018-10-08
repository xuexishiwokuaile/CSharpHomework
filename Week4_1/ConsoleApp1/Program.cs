using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Week3_1
{
    class Program
    {
        class Clock
        {
            public event EventHandler ring;
            protected virtual void OnRing()
            {
                EventHandler temp = ring;
                if (temp != null) temp(this, EventArgs.Empty);
            }

            public void SimulateClockRingning()
            {
                Console.WriteLine("Ringing");

                OnRing();
            }
        }

        class Alert
        {
            public Alert(Clock c)
            {
                Console.WriteLine("Create a new Alert");
                c.ring += c_ring;
            }

            void c_ring(object sender, EventArgs e)
            {
                Console.WriteLine("Time out");
            }

            public void UnRegister(Clock c)
            {
                c.ring -= c_ring;
            }
        }

        static void Main(string[] args)
        {
            Clock myClock = new Clock();
            Alert Darkterror = new Alert(myClock);

            myClock.SimulateClockRingning();
        }
    }
}