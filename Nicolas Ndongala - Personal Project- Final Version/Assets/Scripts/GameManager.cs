using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 20;
    public GameObject powerupPrefab;
    public TextMeshProUGUI gameOverText;
    private int score;
    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
      
        SpawnEnemyWave(1);
        StartCoroutine(SpawnNewEnemy());
        StartCoroutine(SpawnPowerup());
        score = 0;
        scoreText.text = "Score: " + score; UpdateScore(0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiestoSpawn)
    {
        for (int i = 0; i < enemiestoSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(),
                enemyPrefab.transform.rotation);
        }
    }


    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
             yield return new WaitForSeconds(6);
            SpawnEnemyWave(1);
           
        }
    }

    IEnumerator SpawnPowerup()
    {
        while (true)
        {
           yield return new WaitForSeconds(15);
            Instantiate(powerupPrefab, GenerateSpawnPosition(),
                 powerupPrefab.transform.rotation);
        }

    }
    
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }    
    
  
}
