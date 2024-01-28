using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitChecker : MonoBehaviour
{
    [SerializeField] private int exit_num;
    [SerializeField] public MazeMaster mazeMaster;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mazeMaster.StoreExitNum(exit_num);
    }


}
