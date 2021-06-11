using CameraKit;
using UnityEngine;

namespace RollBall
{
    public class BonusControllerEventBinder : MonoBehaviour
    {
        [SerializeField] private CameraShake cameraShake;
        [SerializeField] private BonusController bonusController;

        private void Start()
        {
            bonusController.OnSubtractPointBonusCollected += cameraShake.Shake;
        }
    }
    
}