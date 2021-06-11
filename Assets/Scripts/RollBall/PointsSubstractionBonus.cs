namespace RollBall
{



    public class PointsSubstractionBonus : BonusBase
    {
        public override void DoBonus(BonusController bonusController)
        {
            bonusController.PointsSubtractionBonus();
        }
    }
}
