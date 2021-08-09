using UnityEngine;
using UnityEngine.Profiling;

namespace RollBall
{
   public sealed class PlayerBall : Player
   {
      private void FixedUpdate()
      {
         Move();
      }
   }
}
