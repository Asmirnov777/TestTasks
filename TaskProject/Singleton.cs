namespace TaskProject
{
    class Singleton
    {
        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Singleton();
                }
            }
            return instance;
        }

        private static Singleton instance;

        private static object locker = new object();
    }
}
