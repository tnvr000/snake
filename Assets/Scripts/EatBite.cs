using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EatBite : MonoBehaviour {
	void OnTriggerEnter (Collider collider)
	{
		Debug.Log("Was that edible");
		if(collider.tag == "Bite")
		{
			Debug.Log("Yes! This is a bite");
			gameObject.GetComponentInParent<SnakeManager>().GrowSnake();
		}
		else if(collider.tag == "Player")
		{
			Debug.Log("GAME OVER");
			gameObject.GetComponentInParent<SnakeManager>().enabled = false;
			gameObject.GetComponentInParent<Turn>().enabled = false;
			StartCoroutine(RestartGame());
		}
	}
	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
