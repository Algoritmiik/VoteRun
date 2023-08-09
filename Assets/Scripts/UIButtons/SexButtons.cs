using UnityEngine;

public class SexButtons : MonoBehaviour
{
    [SerializeField] private PlayerSexSwitcher playerSexSwitcher;

    public void MaleButtonPressed()
    {
        playerSexSwitcher.SwitchToMale();
    }

    public void FemaleButtonPressed()
    {
        playerSexSwitcher.SwitchToFemale();
    }
}
