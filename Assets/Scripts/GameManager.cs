using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currStreak = 0;
    public static bool isPlaying;

    private void Awake()
    {
        isPlaying = true;
    }

    private void OnApplicationPause(bool pause)
    {
        isPlaying = !pause;
    }

}
