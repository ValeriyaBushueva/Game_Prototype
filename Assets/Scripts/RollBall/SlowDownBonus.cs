

namespace RollBall
{
    public class SlowDownBonus : BonusBase
    {
        public override void DoBonus(BonusController bonusController)
        {
            bonusController.SlowDownBonus();
        }
    }
}
