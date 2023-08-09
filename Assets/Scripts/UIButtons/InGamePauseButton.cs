using UnityEngine;

public class InGamePauseButton : MonoBehaviour
{
    public void InGamePauseButtonPressed()
    {
        GameManager.Instance.PauseGame();
    }
}
