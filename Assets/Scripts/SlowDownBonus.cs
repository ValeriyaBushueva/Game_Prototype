using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SlowDownBonus : BonusBase
{
    public override void DoBonus(BonusController bonusController)
    {
        bonusController.SlowDownBonus();
    }
}
