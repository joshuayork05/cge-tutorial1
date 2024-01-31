using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMaster : MonoBehaviour
{
    [SerializeField] public TopDownCharacterController player_info;

    private int exit_num;
    private int cor_exit_num;

    //Setting the defaults for progression phases in the areas
    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;

    Vector3 mazeStart;

    private void Start()
    {
        UpdateExitValues();
    }

    //gets and stores the exit number of any exit collided with
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
            UpdateCurrentPhase(true);
        }
        else
        {
            Debug.Log("Wrong exit");
            UpdateCurrentPhase(false);
        }
    }

    private void UpdateCurrentPhase(bool correct_exit)
    {
        if (correct_exit)
        {
            if (phase1 == true)
            {
                phase1 = false;
                phase2 = true;
            }
            else if (phase2 == true)
            {
                phase2 = false;
                phase3 = true;
            }
            else if (phase3 == true)
            {
                EndOfMaze();
            }

            UpdateExitValues();

        }
        else
        {
            ResetMaze();
        }
    }

    //updates the correct exit
    private void UpdateExitValues()
    {
        if (phase1 == true)
        {
            cor_exit_num = 1;
        }
        else if (phase2 == true)
        {
            cor_exit_num = 3;
        }
        else if (phase3 == true)
        {
            cor_exit_num = 2;
        }
    }

    private void ResetMaze()
    {
        mazeStart = new Vector3(-11.5f, 5f, 0f);

        phase1 = true;
        phase2 = false;
        phase3 = false;

        UpdateExitValues();

        player_info.UpdatePlayerSpeed(0f);
        player_info.transform.position = mazeStart;
        player_info.UpdatePlayerSpeed(1f);
    }

    private void EndOfMaze()
    {
        Debug.Log("You have successfully escaped!");
    }
}
