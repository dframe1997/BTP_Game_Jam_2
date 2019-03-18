using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public Button StartButton;

    public void startButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    void Start()
    {
        StartButton.onClick.AddListener(startButtonClicked);
    }
}
