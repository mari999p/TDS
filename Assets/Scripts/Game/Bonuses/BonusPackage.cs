using UnityEngine;

namespace TDS.Game.Bonuses
{
    public abstract class BonusPackage : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions() { }

        #endregion
    }
}