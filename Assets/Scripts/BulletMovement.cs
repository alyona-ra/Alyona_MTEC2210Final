using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{

    public float speed = 3.0f;
    public Vector3 bulletDirection = Vector3.up;
    private AudioClip enemyKilled;
    private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletMovement = bulletDirection * speed * Time.deltaTime;
        transform.Translate(bulletMovement);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Top")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            GameManager.gameScore += collision.gameObject.GetComponent<EnemyMovement>().score;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}