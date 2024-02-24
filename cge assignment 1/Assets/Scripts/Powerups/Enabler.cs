using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    [SerializeField] GameObject baseObject;
    [SerializeField] GameObject enabledObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (baseObject.activeSelf == false)
        {
            enabledObject.SetActive(true);
        }
    }
}
