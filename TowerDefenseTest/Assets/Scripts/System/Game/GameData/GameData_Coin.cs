using System;
using UnityEngine;

public class GameData_Coin
{
    public int Coins { get; private set; }

    public Action OnCoinChanged;

    public GameData_Coin(int initialCoins)
    {
        Coins = initialCoins;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        OnCoinChanged?.Invoke();
    }
    public void RemoveCoins(int amount)
    {
        Coins -= amount;
        if (Coins < 0) Coins = 0;
        OnCoinChanged?.Invoke();
    }
}
