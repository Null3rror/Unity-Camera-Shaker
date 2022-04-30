using UnityEngine;

namespace _Project.Scripts.Core
{
    public class FollowTarget : MonoBehaviour
    {    
        [Tooltip("Speed at which the camera rotates. (uses Slerp for rotation.)")]
        public float rotateSpeed = 90.0f;

        [Tooltip("If the Target is using FixedUpdate for movement, check this box for smoother movement.")]
        public bool usedFixedUpdate = true;

        [Tooltip("This will be the new parent of the FollowTarget")]
        public Transform container;
    
        private Transform _target;
        private Vector3 _startOffset;

        private void Start()
        {
            _startOffset = transform.localPosition;
            _target = transform.parent;
            if (_target == null)
            {
                Debug.LogError("FollowTarget needs a target to function.\n Its parent will act as a target, so provide a parent for FollowTarget's game object.");
            }
            transform.SetParent(container, false);
        }

        private void Update()
        {
            if (!usedFixedUpdate)
                Follow();
        }

        private void FixedUpdate()
        {
            if (usedFixedUpdate)
                Follow();
        }

        private void Follow()
        {
            transform.position = _target.TransformPoint(_startOffset);
            transform.rotation = Quaternion.Slerp(transform.rotation, _target.rotation, rotateSpeed * Time.deltaTime);
        }
    }
}