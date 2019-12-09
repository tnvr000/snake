using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public int theme;
    public float snakeStepInterval;
    public GameManager gameManager;
    public Transform[] snake;
    public Texture[] snakeHeadTextures;
    public Texture[] snakeBodyTextures;
    private float TimeElapsed;
    private Vector3 direction;
    void Start()
    {
        UpdateSnake();
    }

    void Update()
    {
        if (TimeElapsed > snakeStepInterval + 0.05f)
        {
            TakeStep();
            TimeElapsed = 0f;
        }
        TimeElapsed += Time.deltaTime;
    }

    void UpdateSnake()
    {
        snake = new Transform[gameObject.transform.childCount];
        for (int i = 0; i < snake.Length; ++i)
        {
            snake[i] = gameObject.transform.GetChild(i);
        }
    }

    public void GrowSnake()
    {
        int snakeTailIndex = snake.Length - 1;
        direction = GetDirection(snake[snakeTailIndex]);
        Vector3 position = snake[snakeTailIndex].position - direction;
        Quaternion rotation = snake[snakeTailIndex].rotation;
        Transform tail = Instantiate(snake[snakeTailIndex], position, rotation, gameObject.transform);
        tail.gameObject.name = "SnakeBody" + snakeTailIndex;
        tail.position = position;
        tail.rotation = rotation;
        snakeStepInterval -= snakeStepInterval * 0.025f;
        UpdateSnake();
    }

    void TakeStep()
    {
        Vector3 newPosition, oldPosition;
        Quaternion newRotation, oldRotation;
        direction = GetDirection(snake[0]);
        newPosition = snake[0].transform.position + direction;
        newRotation = snake[0].transform.rotation;
        for (int snakeBodyIndex = 0; snakeBodyIndex < snake.Length; snakeBodyIndex++)
        {
            oldPosition = snake[snakeBodyIndex].transform.position;
            oldRotation = snake[snakeBodyIndex].transform.rotation;
            snake[snakeBodyIndex].transform.position = newPosition;
            snake[snakeBodyIndex].transform.rotation = newRotation;
            newPosition = oldPosition;
            newRotation = oldRotation;
        }
        gameObject.transform.GetChild(0).GetComponent<Turn>().canTurn = true;
        UpdateSnakeTexture();
    }

    void UpdateSnakeTexture()
    {
        Texture texture;
        for (int snakeBodyIndex = 0; snakeBodyIndex < snake.Length; snakeBodyIndex++)
        {
            texture = GetTexture(snakeBodyIndex);
            snake[snakeBodyIndex].GetComponent<Renderer>().material.mainTexture = texture;
        }
    }

    int GetTextureID(int snakeBodyIndex)
    {
        int textureID;
        int currentBodyAngle, followingBodyAngle;
        currentBodyAngle = (int)snake[snakeBodyIndex].eulerAngles.y;
        currentBodyAngle = currentBodyAngle == -90 ? 270 : currentBodyAngle;
        if (snakeBodyIndex < snake.Length - 1)
        {
            followingBodyAngle = (int)snake[snakeBodyIndex + 1].eulerAngles.y;
            followingBodyAngle = followingBodyAngle == -90 ? 270 : followingBodyAngle;
            textureID = followingBodyAngle - currentBodyAngle;
        }
        else
        {
            textureID = 3;
        }

        return textureID;
    }

    Texture GetTexture(int snakeBodyIndex)
    {
        int textureID = GetTextureID(snakeBodyIndex);
        int textureIndex = 0;
        if (snakeBodyIndex == 0)
        {
            if (textureID == -90 || textureID == 270)
            {
                textureIndex = 2;
            }
            else if (textureID == 90 || textureID == -270)
            {
                textureIndex = 1;
            }
            return snakeHeadTextures[textureIndex];
        }
        else
        {
            if (textureID == 3)   //tail
            {
                textureIndex = 3;
            }
            else if (textureID == -90 || textureID == 270) //Left
            {
                textureIndex = 2;
            }
            else if (textureID == 90 || textureID == -270)  //Right
            {
                textureIndex = 1;
            }
            if (snakeBodyIndex % 4 == 0) 
            {
                textureIndex = textureIndex + 4;
            }

            //textureIndex += snakeBodyIndex % 3;
            return snakeBodyTextures[textureIndex];
        }
    }

    Vector3 GetDirection(Transform snakeBody)
    {
        float radian = snakeBody.eulerAngles.y * Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Sin(radian), 0f, Mathf.Cos(radian));
        return direction;
    }
}
