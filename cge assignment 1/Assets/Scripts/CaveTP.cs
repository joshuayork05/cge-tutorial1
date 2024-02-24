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

    Color32 CaveColour = new Color32(107, 70, 116,1);
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sun.color = CaveColour;
            player.transform.position = tpPoint;
        }
    }
}
