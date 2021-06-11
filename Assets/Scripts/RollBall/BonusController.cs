using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace RollBall
{
    public class BonusController : MonoBehaviour
    {

        [SerializeField] private float timerSpeed = 7f;
        [SerializeField] private float accelerateSpeed = 15;
        [SerializeField] private float slowSpeed = 0.1f;

        [SerializeField] private TextMeshProUGUI gameOverText;
        private BonusController bonusController;
        public static bool GameIsOver = false;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private int currentScore;
        [SerializeField] private Player player;

        public event Action OnSubtractPointBonusCollected;


        public void GameOverBonus()
        {
            gameOverText.gameObject.SetActive(true);
            GameIsOver = true;
            Time.timeScale = 0;
        }

        public void AddScoreBonus(int scoreValue)
        {

            currentScore += scoreValue;

            if (currentScore < 0)
            {
                currentScore = 0;
            }

            scoreText.text = "Score:" + currentScore;

        }

        public void PointsSubtractionBonus()
        {
            OnSubtractPointBonusCollected?.Invoke();
        }

        public void SlowDownBonus()
        {
            StartCoroutine(SlowDownBonusProcess());
        }

        private IEnumerator SlowDownBonusProcess()
        {
            player.Speed -= slowSpeed;
            yield return new WaitForSeconds(timerSpeed);
            player.Speed += slowSpeed;
        }

        public void AccelerationBonus()
        {
            StartCoroutine(AccelerationBonusProcess());
        }

        private IEnumerator AccelerationBonusProcess()
        {
            player.Speed += accelerateSpeed;
            yield return new WaitForSeconds(timerSpeed);
            player.Speed -= accelerateSpeed;
        }
    }
}
