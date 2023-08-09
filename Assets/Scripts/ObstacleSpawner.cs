using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle obstacleToSpawn;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject finishFlag;
    [SerializeField] private FloorController floor;
    [SerializeField] private float obstacleTimer;

    public void StartSpawner()
    {
        if (player.transform.position.z < 2f)
            SpawnObstacle();

        StartCoroutine("ObstacleSpawnerCoroutine", obstacleTimer);
    }

    public void StopSpawner()
    {
        StopCoroutine("ObstacleSpawnerCoroutine");
    }

    private IEnumerator ObstacleSpawnerCoroutine(float obstacleTimer)
    {
        while(true)
        {
            yield return new WaitForSeconds(obstacleTimer);
            SpawnObstacle();
        }
    }
    
    private void SpawnObstacle()
    {
        Obstacle obstacle = Instantiate(obstacleToSpawn, obstacleParent);
        obstacle.Player = player;
        SetObstacle(obstacle);
    }

    private void SetObstacle(Obstacle obstacle)
    {
        SetObstacleTransform(obstacle);
    }

    private void SetObstacleTransform(Obstacle obstacle)
    {
        float scale = Random.Range(7.45f, 7.7f);
        var localScale = obstacle.transform.localScale;
        localScale.x = scale;
        obstacle.transform.localScale = localScale;
        SetObstaclePosition(scale, obstacle);
    }

    private void SetObstaclePosition(float scale, Obstacle obstacle)
    {
        var chance = Random.Range(0f, 1f);
        float position = SetObstacleTransformByChance(scale, chance, obstacle);

        var obstaclePos = obstacle.transform.position;
        var playerPos = player.transform.position;

        obstaclePos.x = position;

        float zPos = playerPos.z + 15f;
        if (zPos > finishFlag.transform.position.z - 5f)
        {
            StopSpawner();
            zPos = finishFlag.transform.position.z - 5f;
        }
        obstaclePos.z = zPos;

        obstacle.transform.position = obstaclePos;
    }

    private float SetObstacleTransformByChance(float scale, float chance, Obstacle obstacle)
    {
        float position;
        var obstacleMaxPos = (floor.transform.localScale.x / 2f) - (scale / 2f) - 1.3f;

        if (chance >= 0f && chance < 0.45f)
            position = Random.Range(obstacleMaxPos - (7.7f - scale), obstacleMaxPos);
        else if (chance >= 0.45f && chance < 0.9f)
            position = Random.Range(obstacleMaxPos * -1f, (obstacleMaxPos - (7.7f - scale)) * -1f);
        else
        {
            position = 0f;

            var localScale = obstacle.transform.localScale;
            localScale.x = floor.transform.localScale.x;
            obstacle.transform.localScale = localScale;
        }

        return position;
    }
}