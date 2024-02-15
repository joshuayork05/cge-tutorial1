using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjChecker : MonoBehaviour
{
    [SerializeField] MemoryMaster puzzleMaster;
    [SerializeField] private int object_number;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puzzleMaster.GetObjectNumber(object_number);
    }
}
