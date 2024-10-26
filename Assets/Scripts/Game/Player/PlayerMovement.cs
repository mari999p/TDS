using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        private Camera _camera;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Private methods

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 direction = new(horizontal, vertical);
            Vector2 velocity = direction.normalized * _speed;
            _rb.velocity = velocity;
            _animation.SetMovement(direction.magnitude);
        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
            mouseWorldPoint.z = transform.position.z;
            transform.up = mouseWorldPoint - transform.position;
        }

        #endregion
    }
}