using System;

public static class EventManager
{
    public static event Action<int> IncreaseScoreEvent;
    public static event Action<int> PlayerDamagedEvent;
    public static event Action GameOverEvent;

    public static void GameOver()
    {
        GameOverEvent?.Invoke();
    }

    public static void IncreaseSore(int scoreIncrease)
    {
        IncreaseScoreEvent?.Invoke(scoreIncrease);
    }

    public static void PlayerDamaged(int damage)
    {
        PlayerDamagedEvent?.Invoke(damage);
    }
}
