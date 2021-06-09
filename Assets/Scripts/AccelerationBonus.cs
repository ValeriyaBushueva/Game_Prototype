using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public sealed class AccelerationBonus :BonusBase
{
    public override void DoBonus(BonusController bonusController)
    {
        bonusController.AccelerationBonus();
    }
}
