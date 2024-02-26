using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealDoor : MonoBehaviour
{
    [SerializeField] GameObject Gobject;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Gobject.SetActive(true);
    }
}
