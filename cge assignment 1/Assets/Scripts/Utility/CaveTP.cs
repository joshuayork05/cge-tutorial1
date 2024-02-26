using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CaveTP : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector2 tpPoint;
    [SerializeField] Light2D sun;
    [SerializeField] MusicController music;

    Color32 CaveColour = new Color32(107, 70, 116,1);
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateMusic();
            sun.color = CaveColour;
            player.transform.position = tpPoint;
        }
    }

    private void UpdateMusic()
    {
        music.StopMusic("overworld");
        music.StartMusic("underground");
    }
}
