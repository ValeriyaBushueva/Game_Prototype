

namespace RollBall
{
    public class BadBonus : BonusBase
    {
        public override void DoBonus(BonusController bonusController)
        {
            bonusController.GameOverBonus();
        }
    }
}
