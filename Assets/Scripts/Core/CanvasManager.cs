using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> canvasControllerList;
    [SerializeField] private List<GameObject> voiceButtons;
    [SerializeField] private List<GameObject> muteButtons;

    void Awake()
    {
        foreach (var canvas in canvasControllerList)
        {
            canvas.SetActive(false);
        }

        var mainMenuCanvas = canvasControllerList.Find(x => x.name == "MainMenu");
        mainMenuCanvas.SetActive(true);

        EnableVoiceButtons();
    }

    public void GameStarted()
    {
        foreach (var canvas in canvasControllerList)
        {
            canvas.SetActive(false);
        }
        
        var inGameCanvas = canvasControllerList.Find(x => x.name == "InGame");
        inGameCanvas.SetActive(true);
    }

    public void GamePaused()
    {
        foreach (var canvas in canvasControllerList)
        {
            canvas.SetActive(false);
        }
        
        var gamePausedCanvas = canvasControllerList.Find(x => x.name == "GamePaused");
        gamePausedCanvas.SetActive(true);
    }

    public void GameResumed()
    {
        foreach (var canvas in canvasControllerList)
        {
            canvas.SetActive(false);
        }
        
        var inGameCanvas = canvasControllerList.Find(x => x.name == "InGame");
        inGameCanvas.SetActive(true);
    }

    public void GameFinished()
    {
        foreach (var canvas in canvasControllerList)
        {
            canvas.SetActive(false);
        }
        
        var endGameCanvas = canvasControllerList.Find(x => x.name == "EndGame");
        endGameCanvas.SetActive(true);
    }

    public void EnableVoiceButtons()
    {
        foreach (var muteButton in muteButtons)
        {
            muteButton.SetActive(false);
        }

        foreach (var voiceButton in voiceButtons)
        {
            voiceButton.SetActive(true);
        }
    }

    public void DisableVoiceButtons()
    {
        foreach (var voiceButton in voiceButtons)
        {
            voiceButton.SetActive(false);
        }

        foreach (var muteButton in muteButtons)
        {
            muteButton.SetActive(true);
        }
    }
}
