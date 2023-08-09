using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartGameButtonPressed()
    {
        GameManager.Instance.StartGame();
    }
}
