using UnityEngine;

namespace TDS.Game.Bonuses
{
    public abstract class BonusPackage : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Player))
            {
                PerformActions(other);
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions(Collider2D other) { }

        #endregion
    }
}