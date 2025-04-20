namespace ProducerConsumer
{
    internal class ProducerConsumerManager
    {
        private const int PRODUCER_COUNT = 2;
        private const int CONSUMER_COUNT = 2;
        private const int CAPACITY = 5;

        private readonly List<string> list = new List<string>();
        private readonly object obj = new object();

        public void Start()
        {
            for (int i = 0; i < CONSUMER_COUNT; i++)
            {
                Thread consumer = new Thread(new Consumer(this).Run);

                consumer.Start();
            }

            for (int i = 0; i < PRODUCER_COUNT; i++)
            {
                Thread producer = new Thread(new Producer(this).Run);

                producer.Start();
            }
        }

        public string GetItem()
        {
            lock (obj)
            {
                while (list.Count <= 0)
                {
                    Monitor.Wait(obj);
                }

                string result = list[list.Count - 1];
                
                list.RemoveAt(list.Count - 1);

                Monitor.PulseAll(obj);

                return result;
            }
        }

        public void AddItem(string item)
        {
            lock (obj)
            {
                while (list.Count > CAPACITY)
                {
                    Monitor.Wait(obj);
                }

                list.Add(item);

                Monitor.PulseAll(obj);
            }
        }
    }
}
