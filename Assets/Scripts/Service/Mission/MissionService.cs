using System;
using TDS.Infrastructure.Locator;
using TDS.Utils.Log;
using UnityEngine;
using UnityEngine.Assertions;

namespace TDS.Service.Mission
{
    public class MissionService : MonoBehaviour, IService
    {
        #region Variables

        private readonly MissionFactory _factory = new();

        private Mission _currentMission;

        #endregion

        #region Events

        public event Action OnCompleted;
        public event Action OnStarted;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _currentMission?.Update();
        }

        #endregion

        #region Public methods

        public void Begin()
        {
            Assert.IsNotNull(_currentMission);
            _currentMission.Begin();
            OnStarted?.Invoke();
        }

        public void Dispose()
        {
            if (_currentMission != null)
            {
                _currentMission.OnCompleted -= MissionCompletedCallback;
                _currentMission.Stop();
            }

            _currentMission = null;
        }

        public void Initialize()
        {
            MissionConditionHolder holder = FindObjectOfType<MissionConditionHolder>();
            _currentMission = _factory.Create(holder.MissionCondition);
            _currentMission.OnCompleted += MissionCompletedCallback;
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            this.Error();
            OnCompleted?.Invoke();
        }

        #endregion
    }
}