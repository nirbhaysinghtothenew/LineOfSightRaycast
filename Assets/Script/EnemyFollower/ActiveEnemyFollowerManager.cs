using UnityEngine;

namespace Script
{
    public class ActiveEnemyFollowerManager
    {
        private static readonly object _lock = new object();
        private static ActiveEnemyFollowerManager _instance;
        public static ActiveEnemyFollowerManager Instance
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
                            _instance = new ActiveEnemyFollowerManager();
                        }
                    }
                }
                return _instance;
            }
        }
        
        private static int _noOfActiveEnemy = 0;

        public void IncreaseCount()
        {
            _noOfActiveEnemy++;
        }
        
        public void DecreaseCount()
        {
            _noOfActiveEnemy--;
        }
        
        public void Reset()
        {
            _noOfActiveEnemy = 0;
        }

        public int GetActiveNoOfEnemy()
        {
            return _noOfActiveEnemy;
        }
    }
}