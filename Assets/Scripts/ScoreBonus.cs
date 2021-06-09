﻿using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreBonus : BonusBase
    {
        [SerializeField] private int scoreValue;
        public override void DoBonus(BonusController bonusController)
        {
            bonusController.AddScoreBonus(scoreValue);
        }
    }
}