using UnityEngine;

public static class GameController
{
    public static int score;
    public static float timeLeft;

    public static bool gameOver
    {
        get {
            return timeLeft <= 0;
        }
    }

    public static void Init()
    {
        score = 0;
        timeLeft = 30f;
    }

    public static void CollectableCollected()
    {
        score++;
        timeLeft += 1f;
    }
}