using UnityEngine;

namespace RollBall
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Player Player;
        [SerializeField] private Vector3 offset;

        void Start()
        {
            offset = transform.position - Player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = Player.transform.position + offset;
        }
    }
}
