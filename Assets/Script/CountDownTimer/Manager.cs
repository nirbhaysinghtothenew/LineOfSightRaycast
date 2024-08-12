using UnityEngine;

namespace Script.CountDownTimer
{
    public class Manager
    {
        private static readonly object _lock = new object();
        private static Manager _instance;
        public static Manager Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Manager();
                        }
                    }
                }
                return _instance;
            }
        }
        
        private static float _countDownTime = 0;
        
        public void DecreaseCount()
        {
            _countDownTime -= Time.deltaTime;
        }
        
        public void Set(float maxTime)
        {
            _countDownTime = maxTime;
        }

        public float GetCountDownTime()
        {
            return _countDownTime;
        }
    }
    
}