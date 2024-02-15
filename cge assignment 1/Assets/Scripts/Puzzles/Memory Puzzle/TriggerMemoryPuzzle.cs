using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMemoryPuzzle : MonoBehaviour
{
    [SerializeField] MemoryMaster memoryPuzzle;

    private bool disabled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!disabled)
        {
            memoryPuzzle.ActivatePuzzle();
        }
    }

    public void UpdateState()
    {
        disabled = !disabled;
    }
}
