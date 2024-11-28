using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Spawner spawner;

    public PlayerStatsCanvas playerStatsCanvas;

    public EndGameCanvas endGameCanvas;

    void Start()
    {
        playerStatsCanvas = FindObjectOfType<PlayerStatsCanvas>();

        endGameCanvas = FindObjectOfType<EndGameCanvas>();

        currentHealth = maxHealth;
        spawner = FindObjectOfType<Spawner>();

        playerStatsCanvas.UpdateTowerHealthText(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        playerStatsCanvas.UpdateTowerHealthText(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
            endGameCanvas.TurnOnLoseScreen();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        spawner.LoseGame();
    }
}
