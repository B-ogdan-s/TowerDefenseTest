using UnityEngine;

public class GameState_Preparation : GameState
{
    public GameState_Preparation(GameStateData data) : base(data)
    {
    }

    public override void Enter()
    {
        _data.TimeService.UseDefaultSpeed();
        Game_UI ui = _data.UIManager.OpenPanel<Game_UI>();
        Pause_UI pause_UI = _data.UIManager.GetPanel<Pause_UI>();

        pause_UI.OnContinue = () => _data.SM.ChangeState(typeof(GameState_Preparation));
        ui.OpenStartWave(true);

        _data.TowerHandler.ChangeActionType(true);

        base.Enter();
    }
    public override void Exit()
    {

        base.Exit();
    }
}
