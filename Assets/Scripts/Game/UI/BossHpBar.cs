using TDS.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.UI
{
    public class BossHpBar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Slider _slider;
        [SerializeField] private BossHp _bossHp;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            if (_bossHp == null)
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

        public void Construct(BossHp bossHp)
        {
            Clear();

            _bossHp = bossHp;
            Init();
        }

        #endregion

        #region Private methods

        private void BossDefeatedCallback()
        {
            gameObject.SetActive(false);
        }

        private void Clear()
        {
            if (_bossHp != null)
            {
                _bossHp.OnBossDefeated -= BossDefeatedCallback;
                _bossHp._hp.OnChanged -= HpChangedCallback;
            }
        }

        private void HpChangedCallback(int hp)
        {
            UpdateUi();
        }

        private void Init()
        {
            _bossHp.OnBossDefeated += BossDefeatedCallback;
            _bossHp._hp.OnChanged += HpChangedCallback;
            UpdateUi();
        }

        private void UpdateUi()
        {
            _slider.value = _bossHp._hp.Current / (float)_bossHp._hp.Max;
        }

        #endregion
    }
}