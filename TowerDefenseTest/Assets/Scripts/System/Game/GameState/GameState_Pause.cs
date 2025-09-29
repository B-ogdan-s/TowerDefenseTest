using UnityEngine;

public class GameState_Pause : GameState
{
    public GameState_Pause(GameStateData data) : base(data)
    {
    }

    public override void Enter()
    {
        _data.TimeService.Pause();
        Pause_UI ui = _data.UIManager.OpenPanel<Pause_UI>();

        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
