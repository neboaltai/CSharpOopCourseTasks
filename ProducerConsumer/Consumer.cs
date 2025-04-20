using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    internal class Consumer
    {
        private readonly ProducerConsumerManager manager;

        public Consumer(ProducerConsumerManager manager)
        {
            this.manager = manager;
        }

        public void Run()
        {
            while (true)
            {
                string item = manager.GetItem();

                Thread.Sleep(1000);

                Console.WriteLine(item);
            }
        }
    }
}
