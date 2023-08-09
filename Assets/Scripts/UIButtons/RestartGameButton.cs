using UnityEngine;

public class RestartGameButton : MonoBehaviour
{
    public void RestartButtonPressed()
    {
        GameManager.Instance.RestartGame();
    }
}
