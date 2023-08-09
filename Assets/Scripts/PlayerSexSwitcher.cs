using System.Collections.Generic;
using UnityEngine;

public class PlayerSexSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;

    void Awake()
    {
        CheckPlayerSexInfo();
    }

    public void SwitchToMale()
    {
        PlayerPrefs.SetString("PlayerSex", "male");
        PlayerPrefs.Save();
        
        foreach (var player in players)
        {
            player.SetActive(false);
        }
        var misterCandy = players.Find(x => x.name == "MisterCandy");
        misterCandy.SetActive(true);
    }
    
    public void SwitchToFemale()
    {
        PlayerPrefs.SetString("PlayerSex", "female");
        PlayerPrefs.Save();

        foreach (var player in players)
        {
            player.SetActive(false);
        }
        var madamCandy = players.Find(x => x.name == "MadamCandy");
        madamCandy.SetActive(true);
    }

    private void CheckPlayerSexInfo()
    {
        if (PlayerPrefs.HasKey("PlayerSex"))
        {
            string sex = PlayerPrefs.GetString("PlayerSex");
            switch (sex)
            {
                case "male":
                    foreach (var player in players)
                    {
                        player.SetActive(false);
                    }
                    var misterCandy = players.Find(x => x.name == "MisterCandy");
                    misterCandy.SetActive(true);
                    break;

                case "female":
                    foreach (var player in players)
                    {
                        player.SetActive(false);
                    }
                    var madamCandy = players.Find(x => x.name == "MadamCandy");
                    madamCandy.SetActive(true);
                    break;

                default:
                    PlayerPrefs.SetString("PlayerSex", "male");
                    foreach (var player in players)
                    {
                        player.SetActive(false);
                    }
                    misterCandy = players.Find(x => x.name == "MisterCandy");
                    misterCandy.SetActive(true);
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetString("PlayerSex", "male");
            foreach (var player in players)
            {
                player.SetActive(false);
            }
            var misterCandy = players.Find(x => x.name == "MisterCandy");
            misterCandy.SetActive(true);
        }
    }
}
