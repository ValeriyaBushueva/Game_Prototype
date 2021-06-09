using UnityEngine;

namespace DefaultNamespace
{
    public abstract class BonusBase : MonoBehaviour
    {
        private BonusController bonusController;

        private void Start()
        {
            bonusController = FindObjectOfType<BonusController>();
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