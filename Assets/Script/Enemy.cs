using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 45f;
        [SerializeField] private GameObject player;
        [SerializeField] float sightRange = 500;
        [SerializeField] LayerMask obstructionMask;
        [SerializeField] float fieldOfView = 60f;
        
        private bool _hasLineOfSight = false;
        private void Update()
        {
            _hasLineOfSight = IsInLineOfSight();
        }

        private void FixedUpdate()
        {
            if (_hasLineOfSight)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }

        }
        
        void OnDrawGizmos()
        {
            // Draw the field of view for debugging purposes
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(player.transform.position, sightRange);

            Vector3 leftBound = Quaternion.Euler(0, -fieldOfView / 2, 0) * player.transform.forward * sightRange;
            Vector3 rightBound = Quaternion.Euler(0, fieldOfView / 2, 0) * player.transform.forward * sightRange;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(player.transform.position, player.transform.position + leftBound);
            Gizmos.DrawLine(player.transform.position, player.transform.position + rightBound);
        }

        private bool IsInLineOfSight()
        {
            
            RaycastHit hit;
            Vector3 directionToTarget = player.transform.position - transform.position;

            if (Physics.Raycast(transform.position, directionToTarget.normalized, out hit, sightRange, obstructionMask))
            {
                if (hit.collider.CompareTag(Tags.Tags.Player))
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
                    ActiveEnemyFollowerManager.Instance.IncreaseCount();
                    return true;
                }
                else
                {
                    Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
                }
            }
            return false;
        }
        
    }
}
