using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class PatrolPath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform[] _points;

        private int _currentIndex;

        #endregion

        #region Properties

        public IReadOnlyList<Transform> Points => _points;

        #endregion

        #region Public methods

        public void CollectPoints()
        {
            _points = new Transform[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                _points[i] = transform.GetChild(i);
            }
        }

        public Transform GetCurrentPoint()
        {
            return _points[_currentIndex];
        }

        public void SetNextPoint()
        {
            _currentIndex = (_currentIndex + 1) % _points.Length;
        }

        #endregion
    }
}