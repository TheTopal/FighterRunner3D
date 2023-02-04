using Dreamteck.Splines;
using DG.Tweening;
using UnityEngine;

namespace FR.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Input Control")]
        float _touchX = 0f;
        float _newX = 0f;
        const float clampX = 25f;
        [SerializeField] float speedX;

        [Header("Movement")]
        [SerializeField] SplineFollower splineFollower;
        Transform playerTransform;
        bool isStopped;
        [SerializeField] float _regularSpeed = 2;
        [SerializeField] float _slowerSpeed = 1;

        [Header("Animation")]
        Animator _animator;
        void Awake()
        {
            _animator = GetComponent<Animator>();
            playerTransform = GetComponent<Transform>();
            playerTransform.DOLocalRotate(new Vector3(0, 55, 0), 0.1f);
            StopFollow();    
        }

        void Update()
        {
            XMovementControl();
        }
        void XMovementControl()
        {
            if (!isStopped)
            { 
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    _touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
                }
                else if (Input.GetMouseButton(0))
                {
                    _touchX = Input.GetAxis("Mouse X");
                }
                else
                {
                    _touchX = 0f;
                }

            _newX = transform.localPosition.x + speedX * _touchX * Time.deltaTime;
            _newX = Mathf.Clamp(_newX, -clampX, clampX);

            Vector3 newLocalPosition = new Vector3(_newX, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = newLocalPosition;
            }
        }

        public void StopFollow()
        {
            isStopped = true;
            splineFollower.follow = false;
        }
        public void StartFollow()
        {
            _animator.SetBool("isRunning", true);
            isStopped= false;
            splineFollower.follow = true;
            playerTransform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
        }
        public void SpeedDuringFight()
        {
            splineFollower.followSpeed = _slowerSpeed;
        }
        public void FollowingSpeed()
        {
            splineFollower.followSpeed = _regularSpeed;
        }

    }
}