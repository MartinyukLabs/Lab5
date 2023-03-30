using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class TrafficLightManager
    {
        Semaphore semaphore = new Semaphore(2, 2);

        object lockObject = new object();

        int currentGreenLightIndex = 0;
        public void Start()
        {
            Thread trafficLight1Thread = new Thread(new ThreadStart(TrafficLight1));
            Thread trafficLight2Thread = new Thread(new ThreadStart(TrafficLight2));
            Thread trafficLight3Thread = new Thread(new ThreadStart(TrafficLight3));
            Thread trafficLight4Thread = new Thread(new ThreadStart(TrafficLight4));

            trafficLight1Thread.Start();
            trafficLight2Thread.Start();
            trafficLight3Thread.Start();
            trafficLight4Thread.Start();

            Console.ReadKey();
        }

        private void TrafficLight1()
        {
            while (true)
            {
                lock (lockObject)
                    if (currentGreenLightIndex == 0)
                    {
                        Console.WriteLine("Traffic light 1: green");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                        Console.WriteLine("Traffic light 1: red");

                Thread.Sleep(1000);
            }
        }

        private void TrafficLight2()
        {
            while (true)
            {
                lock (lockObject)
                    if (currentGreenLightIndex == 1)
                    {
                        Console.WriteLine("Traffic light 2: green");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                        Console.WriteLine("Traffic light 2: red");

                Thread.Sleep(1000);
            }
        }

        private void TrafficLight3()
        {
            while (true)
            {
                lock (lockObject)
                    if (currentGreenLightIndex == 2)
                    {
                        Console.WriteLine("Traffic light 3: green");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                        Console.WriteLine("Traffic light 3: red");

                Thread.Sleep(1000);
            }
        }

        private void TrafficLight4()
        {
            while (true)
            {
                lock (lockObject)
                    if (currentGreenLightIndex == 3)
                    {
                        Console.WriteLine("Traffic light 4: green");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                        Console.WriteLine("Traffic light 4: red");

                Thread.Sleep(1000);
            }
        }
    }
}
