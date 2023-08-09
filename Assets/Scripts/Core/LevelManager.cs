using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI ProgressBarUIText;
    [SerializeField] private TextMeshProUGUI EndGameInfoPanel;

    public string[] Statuses = { "Hiçkimse", "Kaymakam", "Bld. Başkanı", "Başbakan", "Cumhurbaşkanı", "Kahraman", "Efsane" };
    
    private int statusIndex = 0;
    public int StatusIndex
    {
        get => statusIndex;
        set => statusIndex = (value > Statuses.Length - 1) ? Statuses.Length - 1 : (value < 0) ? 0 : value;
    }

    void Start()
    {
        progressBar.fillAmount = GameManager.Instance.Point / GameManager.Instance.MaxPoint;
        ProgressBarUIText.text = Statuses[StatusIndex];
    }

    public void SetProgressBar()
    {
        StatusIndex = System.Convert.ToInt32(Mathf.Floor(GameManager.Instance.Point / 100));
        ProgressBarUIText.text = Statuses[StatusIndex];

        progressBar.fillAmount = (GameManager.Instance.Point % 100) / GameManager.Instance.MaxPoint;
    }

    public void SetEndGameInfoText(bool isWin)
    {
        if (isWin)
            EndGameInfoPanel.text = $"Tebrikler!\n<color=#7E1811>{Statuses[StatusIndex]}</color>\nOldunuz";
        else
            EndGameInfoPanel.text = $"Maalesef!\n<color=#7E1811>{Statuses[StatusIndex]}</color>\nOlarak Kaldınız";
    }
}