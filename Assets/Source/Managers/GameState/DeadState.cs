using System;
using System.Threading.Tasks;
using Source.UI;
using Source.UI.DeadScreen;

namespace Source.Managers.GameState
{
    public class DeadState : State
    {
        public override void Set()
        {
            WindowManager.Open<DeadScreen>(new DeadScreen.DeadScreenData(GameManager.ScoreManager.Score, Math.Abs(GameManager.ScoreManager.Score - GameManager.ScoreManager.GetRecord) < 0.001));
            GameManager.BoostSpeedMultiplierManager.Reset();
            GameManager.ScoreManager.Reset();
            GameManager.ScoreManager.Disable();
            GameManager.Input.Player.Move.Disable();
        }

        public override void Unset()
        {
            GameManager.ScoreManager.Enable();
            GameManager.Input.Player.Move.Enable();
            GameManager.BoostSpeedMultiplierManager.Init();
            WindowManager.Close<DeadScreen>();
        }
    }
}