using System;
using System.Collections;
using UnityEngine;

namespace TDS.Game
{
    public class Bullet :  MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        

        private void Start()
        {
            _rb.velocity = transform.up * _speed;
            StartCoroutine(DestroyWithLifetimeDelay());
        }

        private IEnumerator DestroyWithLifetimeDelay()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }
    }
}