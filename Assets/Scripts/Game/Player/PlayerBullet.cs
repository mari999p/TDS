using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerBullet : Bullet
    {
        #region Protected methods

        protected override void OnPerformCollision(Collider2D collision)
        {
            base.OnPerformCollision(collision);
            if (collision.CompareTag(Tag.Enemy))
            {
                EnemyHp playerHp = collision.GetComponent<EnemyHp>();
                playerHp.TakeDamage(Damage);
            }
        }

        #endregion
    }
}