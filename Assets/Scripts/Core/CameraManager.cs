using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject endGameCamera;

    void Start()
    {
        endGameCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    public void ChangeCameraToEndGame()
    {
        endGameCamera.SetActive(true);
        mainCamera.SetActive(false);
    }
}
