using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

