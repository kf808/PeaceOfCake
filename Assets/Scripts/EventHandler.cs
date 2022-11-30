using System;

public class EventHandler
{
    public static event Action OnLevelExitOpen;
    public static void LevelExitOpen()
    {
        OnLevelExitOpen?.Invoke(); 
    }

    public static event Action OnRespawnEnemies;
    public static void RespawnEnemies()
    {
        OnRespawnEnemies?.Invoke();
    }
}
