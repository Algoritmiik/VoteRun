using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitButtonPressed()
    {
        GameManager.Instance.QuitGame();
    }
}
