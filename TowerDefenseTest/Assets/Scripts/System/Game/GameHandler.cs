using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameHandler : MonoBehaviour
{
    [Inject] private UI_Manager _uiManager;
    [Inject] private EnemySpawner _enemySpawner;
    [Inject] private TowerHandler _towerHandler;
    [Inject] private TimeService _timeService;

    [Inject] private GameData_Wave _wave;
    [Inject] private GameData_Coin _coin;
    [Inject] private GameData_HP _hp;

    private StateMachine<GameState> _SM;

    private const string MenuSceneName = "MainMenu";

    private void Start()
    {
        CreateSM();
        _enemySpawner.OnSetDamage += _hp.TakeDamage;
        _enemySpawner.OnSetCoin += _coin.AddCoins;
        _enemySpawner.OnClearAll += () =>
        {
            _SM.ChangeState(typeof(GameState_Preparation));
            _wave.AddWave();
        };

        InitializedDataAction();
        InitializedUIAction();
    }

    private void CreateSM()
    {
        _SM = new StateMachine<GameState>();

        GameStateData data = new GameStateData
        {
            SM = _SM,
            GameHandler = this,
            UIManager = _uiManager,
            EnemySpawner = _enemySpawner,
            TowerHandler = _towerHandler,
            TimeService = _timeService,
        };

        Dictionary<Type, GameState> states = new Dictionary<Type, GameState>
        {
            { typeof(GameState_Preparation), new GameState_Preparation(data) },
            { typeof(GameState_Wave), new GameState_Wave(data) },
            { typeof(GameState_Pause), new GameState_Pause(data) },
            { typeof(GameState_Loss), new GameState_Loss(data) }
        };
        _SM.Initialize(states);
        _SM.ChangeState(typeof(GameState_Preparation));
    }

    private void InitializedDataAction()
    {
        Game_UI game_UI = _uiManager.GetPanel<Game_UI>();
        TowerSelector_UI towerSelector_UI = _uiManager.GetPanel<TowerSelector_UI>();

        _coin.OnCoinChanged += () =>
        {
            game_UI.SetCoin(_coin.Coins);
            towerSelector_UI.SetCoin(_coin.Coins);
        };
        _hp.OnHPChanged += () => game_UI.SetHealth(_hp.MaxHP, _hp.CurrentHP);
        _hp.OnDead += () => _SM.ChangeState(typeof(GameState_Loss));

        _wave.OnWaveChanged += () =>
        {
            game_UI.SetWave(_wave.Wave);
        };

        towerSelector_UI.SetCoin(_coin.Coins);
        game_UI.SetCoin(_coin.Coins);
        game_UI.SetHealth(_hp.MaxHP, _hp.CurrentHP);
        game_UI.SetWave(_wave.Wave);
    }

    private void InitializedUIAction()
    {
        Game_UI game_UI = _uiManager.GetPanel<Game_UI>();
        Pause_UI pause_UI = _uiManager.GetPanel<Pause_UI>();
        TowerSelector_UI selector_UI = _uiManager.GetPanel<TowerSelector_UI>();
        Lost_UI lost_UI = _uiManager.GetPanel<Lost_UI>();

        game_UI.OnPause += () => _SM.ChangeState(typeof(GameState_Pause));
        game_UI.OnStartWave += StartWave;

        pause_UI.OnRestart += RestartGame;
        pause_UI.OnExit += Exit;

        selector_UI.OnBuy += _coin.RemoveCoins;

        lost_UI.OnRestart += RestartGame;
        lost_UI.OnExit += Exit;
    }

    public void Exit()
    {
        SceneManager.LoadScene(MenuSceneName);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void StartWave()
    {
        _SM.ChangeState(typeof(GameState_Wave));
        _enemySpawner.StartSpawnEnemy();
    }

    private void OnDestroy()
    {
        _enemySpawner.OnSetDamage -= _hp.TakeDamage;
        _enemySpawner.OnSetCoin -= _coin.AddCoins;
        _enemySpawner.OnClearAll -= () => _SM.ChangeState(typeof(GameState_Preparation));

        _coin.OnCoinChanged = null;
        _hp.OnHPChanged = null;
        _hp.OnDead = null;

        _SM.CurrentState.Exit();

        _wave.Save(SceneManager.GetActiveScene().name);
    }
}
