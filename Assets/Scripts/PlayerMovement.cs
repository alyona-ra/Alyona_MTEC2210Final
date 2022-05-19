using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2.0f;
    public float moveDuration = 0.5f;
    private bool canShoot = true;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            speed = 6.0f;
            GetComponent<SpriteRenderer>().color = new Color(0.6740388f, 0.9339623f, 0.8009345f, 1f);
            canShoot = false;
        }
        else
        {
            speed = 2.0f;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            canShoot = true;
        }
        Movement(speed);

        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnBullet();
            }
            
        }
    }

    public void Movement(float speed)
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float xMovement = xMove * speed * Time.deltaTime;
        transform.Translate(xMovement, 0, 0);


    }

    GameObject SpawnBullet()
    {
        
        Vector3 spawnPos = GetComponent<Transform>().position;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        return bullet;
    }
}
