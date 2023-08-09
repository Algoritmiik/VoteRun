using System.Collections;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Material greenObstacleMat;
    [SerializeField] private Material redObstacleMat;

    private string[] greenObstacleTexts = { "Eğitim", "Bilim", "Kalkınma", "İstihdam", "Huzur", "İndirim" };
    private string[] redObstacleTexts = { "İşsizlik", "Rüşvet", "Enflasyon", "Savaş", "Yolsuzluk", "Zamlar" };

    public PlayerController Player;
    
    private bool isObstacleGreen;

    void Start()
    {
        ConvertObstacle();
        StartCoroutine("ObstacleConverterCoroutine");
    }

    void Update()
    {
        DestroyIfPlayerPassed();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isObstacleGreen)
                GameManager.Instance.EarnPoint();
            else
                GameManager.Instance.LosePoint();
            
            StopCoroutine("ObstacleConverterCoroutine");
            Destroy(gameObject);
        }
    }

    private IEnumerator ObstacleConverterCoroutine()
    {
        while (true)
        {
            float convertTime = Random.Range(0.35f, 0.75f);
            ConvertObstacle();
            yield return new WaitForSeconds(convertTime);
        }
    }

    private void ConvertObstacle()
    {
        var chance = Random.Range(0f, 1f);
        switch (chance)
        {
            case >= .53f:
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = greenObstacleMat;
                isObstacleGreen = true;
                SetObstacleText();
                break;
            
            case < .53f:
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = redObstacleMat;
                isObstacleGreen = false;
                SetObstacleText();
                break;
        }
    }

    private void SetObstacleText()
    {
        var obstacleText = gameObject.GetComponentInChildren<TextMeshPro>();

        if (isObstacleGreen)
            obstacleText.text = greenObstacleTexts[Random.Range(0, greenObstacleTexts.Length)];
        else
            obstacleText.text = redObstacleTexts[Random.Range(0, redObstacleTexts.Length)];
    }

    private void DestroyIfPlayerPassed()
    {
        var distance = Player.transform.position - gameObject.transform.position;
        if (distance.z > 11.4f)
            Destroy(gameObject);
    }

    private void GameResumed()
    {
        StartCoroutine("ObstacleConverterCoroutine");
    }

    private void GamePaused()
    {
        StopCoroutine("ObstacleConverterCoroutine");
    }
}
