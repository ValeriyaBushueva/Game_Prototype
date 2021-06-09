using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class BadBonus : BonusBase
{
    public override void DoBonus(BonusController bonusController)
    {
        bonusController.GameOverBonus();
    }
}
