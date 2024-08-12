namespace Script.LifeManager
{ 
    abstract class Constant
    {
        public static readonly int MaximumLife = 10;
    }

    public class Life
    {
        private static readonly object Lock = new object();
        private static Life _instance;
        public static Life Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Life();
                        }
                    }
                }
                return _instance;
            }
        }
        
        private int _remainingLife = 10;
        
        public void DecreaseLifeCount()
        {
            if (_remainingLife <= 0)
            {
                _remainingLife = 0;
                return;
            }

            _remainingLife--;
        }
        
        public void Reset()
        {
            _remainingLife = Constant.MaximumLife;
        }

        public int GetLifeCount() => _remainingLife;
        
    }
}