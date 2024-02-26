using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Retry()
    {
        FindAnyObjectByType<MusicController>().StopMusic("gameover");
        FindAnyObjectByType<MusicController>().StartMusic("overworld");

        SceneManager.LoadScene("Level1");
    }
}
