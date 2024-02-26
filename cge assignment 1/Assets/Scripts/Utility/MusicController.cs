using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource[] sounds;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        sounds[0].Play();
    }

    public void StartMusic(string name)
    {
        if (name == "overworld")
        {
            sounds[0].Play();
        }
        else if (name == "underground")
        {
            sounds[1].Play();
        }
        else if (name == "boss")
        {
            sounds[2].Play();
        }
        else if (name == "victory")
        {
            sounds[3].Play();
        }
        else if (name == "gameover")
        {
            sounds[4].Play();
        }
        else
        {
            Debug.LogWarning("Music Playing error!");
        }
    }
    
    public void StopMusic(string name)
    {
        if (name == "overworld")
        {
            sounds[0].Stop();
        }
        else if (name == "underground")
        {
            sounds[1].Stop();
        }
        else if (name == "boss")
        {
            sounds[2].Stop();
        }
        else if (name == "victory")
        {
            sounds[3].Stop();
        }
        else if (name == "gameover")
        {
            sounds[4].Stop();
        }
        else
        {
            Debug.LogWarning("Music Stopping error!");
        }
    }

    public void StopAllMusic()
    {
        foreach (var sound in sounds)
        {
            if (sound.isPlaying == true)
            {
                sound.Stop();
            }
        }
    }
}
