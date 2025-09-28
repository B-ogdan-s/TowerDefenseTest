using UnityEngine;

public class GameState_Loss : GameState
{
    public GameState_Loss(GameStateData data) : base(data)
    {
    }
    public override void Enter()
    {
        Time.timeScale = 0f;
        Lost_UI ui = _data.UIManager.OpenPanel<Lost_UI>();

        base.Enter();
    }
    public override void Exit()
    {
        Time.timeScale = 1f;
        base.Exit();
    }
}
