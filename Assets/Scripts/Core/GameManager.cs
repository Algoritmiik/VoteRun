using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private ObstacleSpawner obstacleSpawner;

    private static GameManager instance;
    public static GameManager Instance => instance ??= FindObjectOfType<GameManager>();

    public bool IsPlaying { get; set; } = false;
    public float MaxPoint { get; } = 100f;
    private bool isWin;
    private float point = 0f;
    public float Point
    {
        get => point;
        set => point = (value >= (levelManager.Statuses.Length) * 100) ? (levelManager.Statuses.Length - 1) * 100 + 99.9f : (value < 0) ? 0 : value;
    }

    void Awake()
    {
        SetupInstance();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("isGameRestart"))
        {
            PlayerPrefs.DeleteKey("isGameRestart");
            StartGame();
        }
    }

    public void StartGame()
    {
        IsPlaying = true;
        canvasManager.GameStarted();
        obstacleSpawner.StartSpawner();
    }

    public void PauseGame()
    {
        IsPlaying = false;
        player.StopPlayer();
        canvasManager.GamePaused();
        obstacleSpawner.StopSpawner();
    }

    public void ResumeGame()
    {
        IsPlaying = true;
        canvasManager.GameResumed();
        obstacleSpawner.StartSpawner();
    }

    public void GameFinished()
    {
        IsPlaying = false;
        isWin = CalculateWinOrLose();
        levelManager.SetEndGameInfoText(isWin);
        player.GameFinished(isWin);
        obstacleSpawner.StopSpawner();
        cameraManager.ChangeCameraToEndGame();
        canvasManager.GameFinished();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("isGameRestart", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EarnPoint()
    {
        Point += 80f;
        levelManager.SetProgressBar();
    }

    public void LosePoint()
    {
        Point -= 85f;
        levelManager.SetProgressBar();
    }

    private bool CalculateWinOrLose()
    {
        int halfOfStatuses = levelManager.Statuses.Length / 2;
        if (levelManager.StatusIndex < halfOfStatuses)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void MuteGame()
    {
        audioManager.Mute();
        canvasManager.DisableVoiceButtons();
    }

    public void UnmuteGame()
    {
        audioManager.Unmute();
        canvasManager.EnableVoiceButtons();
    }

    private void SetupInstance()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
