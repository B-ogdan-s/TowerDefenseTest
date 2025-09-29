using UnityEngine;

public class GameState_Wave : GameState
{
    public GameState_Wave(GameStateData data) : base(data)
    {
    }

    public override void Enter()
    {
        _data.TimeService.UsePlaySpeed();
        Game_UI ui = _data.UIManager.OpenPanel<Game_UI>();
        Pause_UI pause_UI = _data.UIManager.GetPanel<Pause_UI>();

        pause_UI.OnContinue = () => _data.SM.ChangeState(typeof(GameState_Wave));

        ui.OpenStartWave(false);

        _data.TowerHandler.ChangeActionType(false);

        base.Enter();
    }
    public override void Exit()
    {

    }
}
