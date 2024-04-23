using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonPlayAgain : MonoBehaviour
{
    [SerializeField] Button btnPlayAgain;

    private void Awake()
    {
        btnPlayAgain.onClick.AddListener(PlayAgain);
    }

    void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
