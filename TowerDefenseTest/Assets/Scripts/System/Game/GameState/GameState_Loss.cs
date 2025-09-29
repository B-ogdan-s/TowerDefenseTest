using UnityEngine;

public class GameState_Loss : GameState
{
    public GameState_Loss(GameStateData data) : base(data)
    {
    }
    public override void Enter()
    {
        _data.TimeService.Pause();
        Lost_UI ui = _data.UIManager.OpenPanel<Lost_UI>();

        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
