using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public void MuteButtonPressed()
    {
        if (PlayerPrefs.HasKey("isSoundOff"))
        {
            PlayerPrefs.DeleteKey("isSoundOff");
            PlayerPrefs.Save();
        }
        GameManager.Instance.UnmuteGame();
    }
}
