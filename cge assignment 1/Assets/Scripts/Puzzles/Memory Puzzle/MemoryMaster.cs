using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MemoryMaster : MonoBehaviour
{
    [SerializeField] TriggerMemoryPuzzle triggerPuzzle;

    private bool phase1;
    private bool phase2;
    private bool phase3;

    //creating the arrays
    private int[] current_solution;
    private int[] player_solution;

    private int player_length = 0;
    private int correct_count = 1;

    private void Awake()
    {
        //initialising the arrays
        current_solution = new int[7];
        player_solution = new int[7];
    }

    public void ActivatePuzzle()
    {
        phase1 = true;
        triggerPuzzle.UpdateState();
        PuzzleSolution(3);
    }


    public void GetObjectNumber(int object_number)
    { 
        player_solution[player_length] = object_number;
        CompareCurrentInput(player_length);

        player_length++;
        CheckPlayerLength();
    }

    private int GenerateObjectNum()
    {
        return UnityEngine.Random.Range(1, 6);
    }

    private void PuzzleSolution(int phase_size)
    {
        int index = 0;
        int count = 0;

        while (count < phase_size)
        {
            current_solution[index] = GenerateObjectNum();
            Debug.Log(current_solution[index]);
            index++;
            count++;
        }
    }

    private void CheckPlayerLength()
    {
        if (phase1 == true && player_length == 3)
        {
            CompareSolutions();
        }
        else if (phase2 == true && player_length == 5)
        {
            CompareSolutions();
        }
        else if (phase3 == true && player_length == 7)
        {
            CompareSolutions();
        }
        else
        {
            Debug.Log("Player length isn't correct");
        }
    }

    private void CompareCurrentInput(int index)
    {
        if (player_solution[index] == current_solution[index])
        {
            Debug.Log("Match");
            correct_count++;
        }
        else
        {
            Debug.Log("Fail");
            ResetPuzzle();
        }
    }

    private void CompareSolutions()
    {
        int count = 0;
        int index = 0;

        if (phase1)
        {
            while (count < 3)
            {
                CompareCurrentInput(index);
                count++;
                index++;
            }
            CheckSolution(3, 1);
        }
        else if (phase2)
        {
            while (count < 5)
            {
                CompareCurrentInput(index);
                count++;
                index++;
            }
            CheckSolution(5, 2);
        }
        else if (phase3)
        {
            while (count < 7)
            {
                CompareCurrentInput(index);
                count++;
                index++;
            }
            CheckSolution(7, 3);
        }
        else
        {
            Debug.Log("Error");
        }
    }

    private void CheckSolution(int phase_requirement, int current_phase)
    {
        if (correct_count == phase_requirement)
        {
            if (current_phase == 1)
            {
                phase1 = false;
                phase2 = true;
                PuzzleSolution(5);
            }
            else if (current_phase == 2)
            {
                phase2 = false;
                phase3 = true;
                PuzzleSolution(7);
            }
            else if (current_phase == 3)
            {
                Debug.Log("Win");
            }
            Console.Clear();
            NextPhaseSetUp();
        }
        else
        {
            Debug.Log("Wrong solution");
            ResetPuzzle();
        }
    }

    private void NextPhaseSetUp()
    {
        correct_count = 0;
        player_length = 0;
    }

    private void ResetPuzzle()
    {
        player_length = 0;
        correct_count = 0;
        phase2 = false;
        phase3 = false;

        for (int i = 0; i <= player_solution.Length - 1; i++)
        {
            player_solution[i] = 0;
        }

        for (int i = 0; i <= current_solution.Length - 1; i++)
        {
            current_solution[i] = 0;
        }

        triggerPuzzle.UpdateState();
    }

}
