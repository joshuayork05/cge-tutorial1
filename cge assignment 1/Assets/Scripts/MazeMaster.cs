using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMaster : MonoBehaviour
{
    private int exit_num;
    private int cor_exit_num;

    //Setting the defaults for progression phases in the areas
    private bool phase1 = false;
    private bool phase2 = false;

    public void StoreExitNum(int exitnum)
    {
        exit_num = exitnum;
        Debug.Log(exit_num);
        CheckExit();
    }

    private void CheckExit()
    {
        if (exit_num == cor_exit_num)
        {
            Debug.Log("Correct exit");
        }
        else
        {
            Debug.Log("Wrong exit");
        }
    }

    private void UpdatePhase(int current_phasenum, bool moveon)
    {
        if (current_phasenum == 0)
        {
            phase1 = !phase1;
        }
        else if (current_phasenum == 1)
        {
            phase2 = !phase2;
        }
        else if (phase2 == true && moveon == true)
        {
            Debug.Log("Finished");
        }
    }

    private void Update()
    {
        if (phase1 == false && phase2 == false)
        {
            cor_exit_num = 1;
        }
        else if (phase1 == true)
        {
            cor_exit_num = 2;
        }
        else if (phase2 == true)
        {
            cor_exit_num = 3;
        }
    }
}
