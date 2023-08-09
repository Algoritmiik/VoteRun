using UnityEngine;

public class FinishFlagController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameFinished();
            gameObject.SetActive(false);
        }
    }
}
