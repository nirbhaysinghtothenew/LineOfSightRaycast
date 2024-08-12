using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Script.EnemyFollower
{
    abstract class Constant
    {
        public static string ActiveEnemy = "Active Enemy: ";
        public static string LifeCount = "Life Count: ";
        
    }

    public class EnemyFollowerScript : MonoBehaviour
    {
        [SerializeField] private List<Transform> enemies;
        [SerializeField] private float speed = 50f;
        [SerializeField] private GameObject player;
        [SerializeField] float sightRange = 500;
        [SerializeField] private LayerMask obstructionMask;
        [SerializeField] private TextMeshProUGUI activeEnemyText;
        [SerializeField] private TextMeshProUGUI lifeCountText;

        private void FixedUpdate()
        {
            bool isGameOver = LifeManager.Life.Instance.GetLifeCount() == 0;
            bool isTimeOver = CountDownTimer.Manager.Instance.GetCountDownTime() == 0;

            if (isGameOver || isTimeOver)
            {
                return;
            }

            ActiveEnemyFollowerManager.Instance.Reset();
            foreach (var enemy in enemies)
            {
                if (IsEnemyFollowing(enemy))
                {
                    ActiveEnemyFollowerManager.Instance.IncreaseCount();
                }
            }

            activeEnemyText.text = Constant.ActiveEnemy + ActiveEnemyFollowerManager.Instance.GetActiveNoOfEnemy();
            lifeCountText.text = Constant.LifeCount + LifeManager.Life.Instance.GetLifeCount();
        }

        private bool IsEnemyFollowing(Transform enemyTransform)
        {
            
            RaycastHit hit;
            Vector3 directionToTarget = player.transform.position - enemyTransform.position;

            if (Physics.Raycast(enemyTransform.position, directionToTarget.normalized, out hit, sightRange, obstructionMask))
            {
                if (hit.collider.CompareTag(Tags.Tags.Player))
                {
                    return true;
                }
            }
            return false;
        }
    }
}