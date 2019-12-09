using UnityEngine;

public class Bite : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().SpawnBite();
            Destroy(gameObject);
        }
    }
}
