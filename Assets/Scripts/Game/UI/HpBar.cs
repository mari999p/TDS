using TDS.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.UI
{
    public class HpBar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Slider _slider;
        [SerializeField] private UnitHp _unitHp;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            if (_unitHp == null)
            {
                return;
            }

            Init();
        }

        private void OnDestroy()
        {
            Clear();
        }

        #endregion

        #region Public methods

        public void Construct(UnitHp unitHp)
        {
            Clear();

            _unitHp = unitHp;
            Init();
        }

        #endregion

        #region Private methods

        private void Clear()
        {
            if (_unitHp != null)
            {
                _unitHp.OnChanged += HpChangedCallback;
            }
        }

        private void HpChangedCallback(int hp)
        {
            UpdateUi();
        }

        private void Init()
        {
            _unitHp.OnChanged += HpChangedCallback;
            UpdateUi();
        }

        private void UpdateUi()
        {
            _slider.value = _unitHp.Current / (float)_unitHp.Max;
        }

        #endregion
    }
}