using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] GameObject[] thingsToCheck;
    [SerializeField] Disabler disabler;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        int disablednum = 0;

        Debug.Log("AAAAAAAAA");

        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < thingsToCheck.Length; i++)
            {
                if (thingsToCheck[i].activeSelf == false)
                {
                    disablednum++;
                }
            }

            if (disablednum == thingsToCheck.Length)
            {
                disabler.DisableObject();
            }
        }
    }
}
