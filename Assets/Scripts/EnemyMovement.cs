using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1.0f;
    public Vector3 enemyDirection = Vector3.down;

    public int score = 10;

    private AudioSource audioSource;
    public AudioClip spawn;
    public AudioClip killed;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(spawn);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyMovement = enemyDirection * speed * Time.deltaTime;
        transform.Translate(enemyMovement);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.gameScore -= score;
            audioSource.clip = killed;
            audioSource.PlayOneShot(killed);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
        }
    }
}