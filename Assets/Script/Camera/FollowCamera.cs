using UnityEngine;

namespace Script.Camera
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform target; 
        public Vector3 offset = new Vector3(0, 0, 0);  
        public float smoothSpeed = 0.125f; // Smoothness factor

        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }
}