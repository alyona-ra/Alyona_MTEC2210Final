using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float totalTime = 180;
    private float remainingTime;
    public bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = totalTime;
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            if (remainingTime > 1)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                Time.timeScale = 0;
                remainingTime = 0;
                isStarted = false;
            }
        }
    }

    public string DisplayTime()
    {
        float min = Mathf.FloorToInt(remainingTime / 60);
        float sec = Mathf.FloorToInt(remainingTime % 60);
        return string.Format("{0:00}:{1:00}", min, sec);
    }
}
