using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Spawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
        spawner = FindObjectOfType<Spawner>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        spawner.LoseGame();
    }
}
