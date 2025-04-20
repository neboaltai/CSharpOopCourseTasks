namespace ProducerConsumer
{
    internal class Producer
    {
        private readonly ProducerConsumerManager manager;

        public Producer(ProducerConsumerManager manager)
        {
            this.manager = manager;
        }

        public void Run()
        {
            int currentNumber = 1;

            while (true)
            {
                Thread.Sleep(1000);

                manager.AddItem("Item " + currentNumber);

                ++currentNumber;
            }
        }
    }
}
