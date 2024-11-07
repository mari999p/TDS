using System;
using System.Collections.Generic;
using TDS.Infrastructure.Locator;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace TDS.Service.PickUp
{
    public class PickUpService : MonoBehaviour, IService
    {
        #region Variables

        [Header("Overall probability")]
        [Range(0f, 100f)]
        [SerializeField] private float _commonProbability;

        [Header("Prefabs list with probabilities")]
        [SerializeField] private List<PickUpAndProbability> _pickUpsVariants;

        #endregion

        #region Public methods

        public void TrySpawnPickup(Vector3 position)
        {
            if (Random.value * 100f <= _commonProbability)
            {
                foreach (PickUpAndProbability pickUp in _pickUpsVariants)
                {
                    if (Random.value * 100f <= pickUp.probability)
                    {
                        Instantiate(pickUp.pickUpPrefab, position, Quaternion.identity);
                        break;
                    }
                }
            }
        }

        #endregion

        #region Local data

        [Serializable]
        private class PickUpAndProbability
        {
            #region Variables

            [FormerlySerializedAs("Name")] [HideInInspector]
            public string name;
            public Game.PickUps.PickUp pickUpPrefab;
            [FormerlySerializedAs("Probability")]
            [Range(0f, 100f)]
            public float probability;

            #endregion

            #region Public methods

            public void Validate()
            {
                name = pickUpPrefab != null ? pickUpPrefab.name : string.Empty;
            }

            #endregion
        }

        #endregion
    }
}