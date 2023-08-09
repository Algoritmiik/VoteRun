using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceButton : MonoBehaviour
{
    public void VoiceButtonPressed()
    {
        PlayerPrefs.SetInt("isSoundOff", 1);
        PlayerPrefs.Save();
        GameManager.Instance.MuteGame();
    }
}
