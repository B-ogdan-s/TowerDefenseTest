using System;

public class GameData_HP
{
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }

    public Action OnHPChanged;
    public Action OnDead;
    public GameData_HP(int maxHP)
    {
        MaxHP = maxHP;
        CurrentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            OnDead?.Invoke();
        }
        OnHPChanged?.Invoke();
    }
}
