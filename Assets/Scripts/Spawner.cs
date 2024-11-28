using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 5;
    public float waveInterval = 10f;
    private int currentWave = 0;
    private bool gameWon = false;
    private bool gameLose = false;
    public PlayerTower playerTower;
    public EndGameCanvas endGameCanvas;


    void Start()
    {
        playerTower = FindObjectOfType<PlayerTower>();

        endGameCanvas = FindObjectOfType<EndGameCanvas>();

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < 5 && !gameWon && !gameLose)
        {
            currentWave++;
            Debug.Log($"Wave {currentWave} started!");

            for (int i = 0; i < enemiesPerWave; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.transform.LookAt(playerTower.gameObject.transform.position);
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(waveInterval);
        }

        if (gameLose == false)
        {
            gameWon = true;
            endGameCanvas.TurnOnWinScreen();
            Debug.Log("You win!");
        }
    }

    public void LoseGame()
    {
        gameLose = true;
    }
}
