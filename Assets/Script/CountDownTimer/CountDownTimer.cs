using UnityEngine;
using TMPro;

namespace Script.CountDownTimer
{
    public class CountDownTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private float totalTime = 60f; // Total time for the countdown in seconds

        void Start()
        {
            Manager.Instance.Set(totalTime);
        }

        void Update()
        {
            bool isGameOver = LifeManager.Life.Instance.GetLifeCount() == 0;
            if (isGameOver)
            {
                return;
            }
            
            float countDownTime = Manager.Instance.GetCountDownTime();
            if (countDownTime> 0)
            {
                Manager.Instance.DecreaseCount();
                UpdateTimerDisplay(countDownTime);
            }
            else
            {
                Manager.Instance.Set(0);
            }
        }

        private void UpdateTimerDisplay(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display the timer in the format mm:ss
        }
    }
}