using System;
using UnityEngine;

namespace _Project.Scripts.CameraShake.Demo
{
    public class TestController : MonoBehaviour
    {
        private const string VerticalAxis = "Vertical";
        private const string HorizontalAxis = "Horizontal";

        [SerializeField, Min(0f)] 
        private float movementSpeed = 50f;

        [SerializeField] 
        private bool usedFixedUpdate;
        
        private CameraShaker _shaker;
        private bool _isShakerNull;
        private float _vertical, _horizontal;
        void Start()
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null) return;
            
            _shaker = mainCamera.GetComponent<CameraShaker>();
            _isShakerNull = _shaker == null;
        }

        void Update()
        {
            if (_isShakerNull) return; 
            Shake();

            _vertical = Input.GetAxis(VerticalAxis);
            _horizontal = Input.GetAxis(HorizontalAxis);

            if (!usedFixedUpdate)
            {
                Move(_horizontal, _vertical);
            }
        }

        private void FixedUpdate()
        {
            if (usedFixedUpdate)
            {
                Move(_horizontal, _vertical);
            }
        }

        private static bool ShouldShake() => Input.GetKeyDown(KeyCode.E);

        private void Shake()
        {
            if (ShouldShake())
            {
                _shaker.BeginShaking();
            }
        }


        private void Move(float horizontal, float vertical)
        {
            Vector3 desiredDir = new Vector3(horizontal, 0f, vertical);
            
            Vector3 normalizedDir = desiredDir;
            if (desiredDir.sqrMagnitude > 1f)
            {
                normalizedDir = desiredDir;
            }

            transform.position += normalizedDir * (movementSpeed * Time.deltaTime);
        }
    }
}
