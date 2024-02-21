using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    [SerializeField] GameObject Gobject;

    public void DisableObject()
    {
        Gobject.SetActive(false);
    }

}
