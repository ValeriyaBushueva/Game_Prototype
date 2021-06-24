using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public abstract class BonusBase : MonoBehaviour
    {
       
        private BonusController bonusController;

        private void Start()
        {
            bonusController = FindObjectOfType<BonusController>();
            if (bonusController == null)
            {
                throw new NullReferenceException(
                    $"No {nameof(BonusController)} component in the scene, please add one!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DoBonus(bonusController);
                Destroy(gameObject);
            }
        }
        
        public abstract void DoBonus(BonusController bonusController);
    }
}