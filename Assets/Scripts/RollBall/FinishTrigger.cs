using UnityEngine;
using UnityEngine.UI;

namespace RollBall
{
    public class FinishTrigger: MonoBehaviour

    {
        [SerializeField] private Image youWinImage;
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                youWinImage.gameObject.SetActive(true);
            }
        }
    }
}