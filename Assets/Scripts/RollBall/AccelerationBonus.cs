

namespace RollBall
{
    public sealed class AccelerationBonus : BonusBase
    {
        public override void DoBonus(BonusController bonusController)
        {
            bonusController.AccelerationBonus();
        }
    }
}
