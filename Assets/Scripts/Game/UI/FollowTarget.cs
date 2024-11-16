using UnityEngine;

namespace TDS.Game.UI
{
    public class FollowTarget: MonoBehaviour
    {
        
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        private void Update()
        {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
            transform.position = _target.position +_offset;
        }
    }
}