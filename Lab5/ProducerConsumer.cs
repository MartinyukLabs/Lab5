using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class ProducerConsumer
    {
        private Queue<int> queue = new Queue<int>();
        private object lockObject = new object();
        public void Start()
        {
            Thread producerThread = new Thread(new ThreadStart(Producer));
            Thread consumerThread = new Thread(new ThreadStart(Consumer));

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();
        }

        private void Producer()
        {
            Random random = new Random();

            while (true)
            {
                int number = random.Next(1, 100);

                lock (lockObject)
                {
                    queue.Enqueue(number);
                    Console.WriteLine($"Producer: {number} is added");
                }

                Thread.Sleep(1000);
            }
        }

        private void Consumer()
        {
            while (true)
            {
                int number;

                lock (lockObject)
                    if (queue.Count > 0)
                    {
                        number = queue.Dequeue();
                        Console.WriteLine($"Consumer: {number} is deleted");
                    }

                Thread.Sleep(1000);
            }
        }
    }
}
