using UnityEngine;
using Zenject;

public class GameDataInstaller : MonoInstaller
{
    [SerializeField] private int _baseCoin = 10;
    [SerializeField] private int _baseHP = 100;
    public override void InstallBindings()
    {
        Container.Bind<GameData_Coin>().AsSingle().WithArguments(_baseCoin).NonLazy();
        Container.Bind<GameData_HP>().AsSingle().WithArguments(_baseHP).NonLazy();
        Container.Bind<GameData_Wave>().AsSingle().NonLazy();
    }
}