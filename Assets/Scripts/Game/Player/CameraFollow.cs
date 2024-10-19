using UnityEngine;

namespace TDS.Game
{
    public class CameraFollow : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _target;
        [SerializeField] private float _zOffset = -10;

        #endregion

        #region Unity lifecycle

        private void LateUpdate()
        {
            Vector3 targetPosition = _target.position;
            targetPosition.z = _zOffset;
            transform.position = targetPosition;
        }

        #endregion
    }
}