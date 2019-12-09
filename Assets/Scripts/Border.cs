using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            float radian = collider.transform.eulerAngles.y * Mathf.Deg2Rad;
            Vector3 position = new Vector3(0f, 0f, 0f);
            Vector3 direction = new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
            if (direction.x == 1|| direction.x == -1)
                position = new Vector3(-(collider.transform.position.x - direction.x), 0f, collider.transform.position.z);
            else if (direction.z == 1|| direction.z == -1)
                position = new Vector3(collider.transform.position.x, 0f, -(collider.transform.position.z - direction.z));
            Debug.Log("Restricted Area");
            collider.transform.position = position;
        }
    }
}
