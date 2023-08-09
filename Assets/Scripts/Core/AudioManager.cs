using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClipArray;

    void Start()
    {
        if (PlayerPrefs.HasKey("isSoundOff"))
            GameManager.Instance.MuteGame();
        Play();
    }

    public void Play()
    {
        audioSource.PlayOneShot(RandomClip());
    } 

    public void Unmute()
    {
        audioSource.volume = 1f;
    }

    public void Mute()
    {
        audioSource.volume = 0f;
    } 

    private AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
}
