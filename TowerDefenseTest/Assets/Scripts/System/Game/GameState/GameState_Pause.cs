using UnityEngine;

public class GameState_Pause : GameState
{
    public GameState_Pause(GameStateData data) : base(data)
    {
    }

    public override void Enter()
    {
        Time.timeScale = 0f;
        Pause_UI ui = _data.UIManager.OpenPanel<Pause_UI>();

        base.Enter();
    }
    public override void Exit()
    {
        Time.timeScale = 1f;
        base.Exit();
    }
}
