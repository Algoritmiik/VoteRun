using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    public void ResumeGameButtonPressed()
    {
        GameManager.Instance.ResumeGame();
    }
}
