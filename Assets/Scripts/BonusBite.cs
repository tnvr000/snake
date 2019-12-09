using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBite : MonoBehaviour
{
    public float stayTime;

    public Color color;
    GameManager gameManager;
    float percentage;
    float timeElapsed;
    float timeRemainingPercentage;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        timeElapsed = 0f;
    }
    void Update()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
        timeElapsed += Time.deltaTime;
        percentage = 1 - (timeElapsed / stayTime);
        color = Color.Lerp(Color.black, Color.cyan, percentage);
       /* if (percentage > 0.5)
        {
            color = new Color(color.r, (percentage - 0.5f) * 2, color.b);
        }
        else
        {
            color = new Color(color.r, color.g, percentage * 2);
        }*/
        
        gameObject.GetComponent<Renderer>().material.color = color;
        if (timeElapsed > stayTime)
        {
            timeElapsed = 0f;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter()
    {
		gameManager.GetComponent<GameManager>().BonusScore(percentage);
        Destroy(gameObject);
    }
}
