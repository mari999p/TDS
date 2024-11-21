using UnityEngine;

namespace TDS.Game.UI
{
    public class HpBarFollower : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        private Camera _camera;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward,
                _camera.transform.rotation * Vector3.up);
            transform.position = _target.position + _offset;
        }

        #endregion
    }
}