using UnityEngine;

public struct GameStateData
{
    public StateMachine<GameState> SM;
    public GameHandler GameHandler;
    public UI_Manager UIManager;
    public EnemySpawner EnemySpawner;
    public TowerHandler TowerHandler;
    public TimeService TimeService;
}

public abstract class GameState : BaseState
{
    protected GameStateData _data;

    public GameState(GameStateData data)
    {
        _data = data;
    }

    public virtual void OpenPause(bool value) { }
    public void StartWabe() { }
    public void EndWave() { }
    public void Loss() { }
}
