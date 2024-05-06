using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonMenu : MonoBehaviour
{
    [SerializeField] Button btnPlay;
    [SerializeField] Button btnQuit;
    private void Awake()
    {
        btnPlay.onClick.AddListener(Play);
        btnQuit.onClick.AddListener(Quit);
    }
    void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
    void Quit()
    {
        Application.Quit();
    }
}
