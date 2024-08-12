using System;
using UnityEngine;

namespace Script
{
    abstract class Constant
    {
        public static readonly string Win = "You Win !!";
        public static readonly string Lose = "You Lose !!";
    }

    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody body;
        [SerializeField] private GameObject gameOverPopup;
        
        private float _xInput;
        private float _zInput;
        private readonly float _speed = 60f;
        private bool _isGameOver = false;

        private void Start()
        {
            LifeManager.Life.Instance.Reset();
            gameOverPopup.SetActive(false);
        }

        private void FixedUpdate()
        {
            _isGameOver = LifeManager.Life.Instance.GetLifeCount() == 0;
            bool isTimeOver = CountDownTimer.Manager.Instance.GetCountDownTime() == 0;
            if (_isGameOver || isTimeOver)
            {
                // Show Popup
                gameOverPopup.SetActive(true);
                string resultText = isTimeOver ? Constant.Win : Constant.Lose;
                gameOverPopup.GetComponent<GameOverPopup>().UpdateResultText(resultText);
            }
            else
            {
                _zInput = Input.GetAxis("Horizontal") * Time.deltaTime;
                _xInput = Input.GetAxis("Vertical") * Time.deltaTime * -1;
                MoveBall();
            }
        }

        private void MoveBall()
        {
            Vector3 movement = new Vector3(_xInput, 0, _zInput);
            transform.Translate(movement * _speed , Space.World);
        }
        

        void OnCollisionEnter(Collision other)
        {
            
            if (other.gameObject.CompareTag(Tags.Tags.Enemy))
            {
                LifeManager.Life.Instance.DecreaseLifeCount();
            }
        }
    }
}
