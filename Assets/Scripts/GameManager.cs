using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int biteScore;
    public int bonusBiteScore;
    public int totalScore;
    public Vector2Int bitePositionLimit;
    public GameObject bite;
    public GameObject bonusBite;
    private int bitesEaten;

    void Start()
    {
        bitesEaten = 0;
        totalScore = 0;
        SpawnBite();
    }
    public void SpawnBite()
    {
        totalScore += biteScore;
        int xCoordinate = Random.Range(-bitePositionLimit.x, bitePositionLimit.x);
        int zCoordinate = Random.Range(-bitePositionLimit.y, bitePositionLimit.y);
        Vector3 position = new Vector3(xCoordinate, bite.transform.position.y, zCoordinate);
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        Instantiate(bite, position, rotation);
        if (bitesEaten++ > 2)
        {
            SpawnBonusBite();
            bitesEaten = 0;
        }
    }

    public void BonusScore(float bonusScorePercentage)
    {

        float score = bonusBiteScore * bonusScorePercentage;
        totalScore += Mathf.RoundToInt(score);
        Debug.Log(score);
        Debug.Log(totalScore);
    }

    void SpawnBonusBite()
    {
        int xCoordinate = Random.Range(-bitePositionLimit.x, bitePositionLimit.x);
        int zCoordinate = Random.Range(-bitePositionLimit.y, bitePositionLimit.y);
        Vector3 position = new Vector3(xCoordinate, bonusBite.transform.position.y, zCoordinate);
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        Instantiate(bonusBite, position, rotation);
    }
}
