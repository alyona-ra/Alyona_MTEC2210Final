using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject[] enemies;

    private float timeRemaining;
    public float spawnDelay = 2.0f;

    private AudioSource audioSource;
    public AudioClip gameOver;
    public AudioClip enemyKilled;
    
    public bool playSound;

    public TextMeshPro timerText;
    private Timer timer;

    public TextMeshPro scoreText;
    
    public static int gameScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeRemaining = spawnDelay;
        timer = GetComponent<Timer>();
        playSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isStarted)
        {
            timerText.text = timer.DisplayTime();
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            timeRemaining = spawnDelay;
        }

        scoreText.text = string.Format("Score: {0:0000}", gameScore);

        if (Time.timeScale == 0)
        {
       
            if (playSound)
            {
                audioSource.PlayOneShot(gameOver);
                playSound = false;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ReloadScene();
                gameScore = 0;
            }
        }
    }

    GameObject SpawnEnemy()
    {

        int index = Random.Range(0, enemySpawnPoints.Length);
        Vector3 spawnPos = enemySpawnPoints[index].position;

        int enemyIndex = Mathf.FloorToInt(Random.Range(0, enemies.Length));
        GameObject enemy = Instantiate(enemies[enemyIndex], spawnPos, Quaternion.identity);

        if (enemyIndex == 0)
        {
            enemy.GetComponent<EnemyMovement>().speed = 1.0f;
            enemy.GetComponent<EnemyMovement>().score = 10;
        }
        else if (enemyIndex == 1)
        {
            enemy.GetComponent<EnemyMovement>().speed = 2.0f;
            enemy.GetComponent<EnemyMovement>().score = 20;
        }
        else if (enemyIndex == 2)
        {
            enemy.GetComponent<EnemyMovement>().speed = 3.0f;
            enemy.GetComponent<EnemyMovement>().score = 30;
        }
        else if (enemyIndex == 3)
        {
            enemy.GetComponent<EnemyMovement>().speed = 4.0f;
            enemy.GetComponent<EnemyMovement>().score = 40;
        }
        else
        {
            enemy.GetComponent<EnemyMovement>().speed = 5.0f;
            enemy.GetComponent<EnemyMovement>().score = 50;
        }

        return enemy;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
