using UnityEngine;

public class Turn : MonoBehaviour {

	public bool canTurn;
	void Update()
	{

		if ((transform.eulerAngles.y == 90 || transform.eulerAngles.y == 270) && canTurn)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				transform.eulerAngles = new Vector3(0f, 0f, 0f);
				canTurn = false;
			}
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				transform.eulerAngles = new Vector3(0f, 180f, 0f);
				canTurn = false;
			}
		}

		if ((transform.eulerAngles.y == 0 || transform.eulerAngles.y == 180) && canTurn)
		{
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				transform.eulerAngles = new Vector3(0f, 90f, 0f);
				canTurn = false;
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				transform.eulerAngles = new Vector3(0f, 270f, 0f);
				canTurn = false;
			}
		}
	}
}
