using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MemoryMaster : MonoBehaviour
{
    [SerializeField] TriggerMemoryPuzzle triggerPuzzle;
    [SerializeField] IndicatorManager indicatorManager;
    [SerializeField] AudioSource incorrect;
    [SerializeField] AudioSource correct;
    [SerializeField] Disabler disabler;

    private bool phase1;
    private bool phase2;
    private bool phase3;

    //creating the arrays
    private int[] current_solution;
    private int[] player_solution;

    private int player_length = 0;
    private int correct_count = 0;

    private void Awake()
    {
        //initialising the arrays
        current_solution = new int[7];
        player_solution = new int[7];
    }

    public void ActivatePuzzle()
    {
        phase1 = true;
        player_length = 0;
        triggerPuzzle.UpdateState();
        StartCoroutine(PuzzleSolution(3));
    }


    public void GetObjectNumber(int object_number)
    { 
        player_solution[player_length] = object_number;

        //Debug.Log($"obj: {object_number}, player: {player_solution[0]}, Solution: {current_solution[0]}");

        indicatorManager.PlayObject(object_number);

        CompareCurrentInput(player_length, false);

        player_length++;
        CheckPlayerLength();
    }

    private int GenerateObjectNum()
    {
        return UnityEngine.Random.Range(1, 6);
    }

    private IEnumerator PuzzleSolution(int phase_size)
    {
        int index = 0;
        int count = 0;

        while (count < phase_size)
        {
            current_solution[index] = GenerateObjectNum();
            Debug.Log(current_solution[index]);

            indicatorManager.PlayObject(current_solution[index]);

            yield return new WaitForSeconds(2);

            index++;
            count++;
        }

        /*
        for (int i = 0; i <= current_solution.Length - 1; i++)
        {
            Debug.Log($"Solution: {current_solution[i]}");
        }*/
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
            //Debug.Log("Player length isn't correct");
        }
    }

    private void CompareCurrentInput(int index, bool counter)
    {

        //Debug.Log($"\nPlayer: {player_solution[index]} - Solution: {current_solution[index]}");

        if (player_solution[index] == current_solution[index])
        {
            //correct.Play();
            Debug.Log("Match");

            if (counter)
            {
                correct_count++;
            }
        }
        else
        {
            //incorrect.Play();
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
                CompareCurrentInput(index, true);
                count++;
                index++;
            }
            CheckSolution(3, 1);
        }
        else if (phase2)
        {
            while (count < 5)
            {
                CompareCurrentInput(index, true);
                count++;
                index++;
            }
            CheckSolution(5, 2);
        }
        else if (phase3)
        {
            while (count < 7)
            {
                CompareCurrentInput(index, true);
                count++;
                index++;
            }
            CheckSolution(7, 3);
        }
    }

    private void CheckSolution(int phase_requirement, int current_phase)
    {
        Debug.Log($"Correct count: {correct_count} - Phase requirement: {phase_requirement} - Current phase: {current_phase}"); 

        if (correct_count == phase_requirement)
        {
            if (current_phase == 1)
            {
                phase1 = false;
                phase2 = true;
                StartCoroutine(PuzzleSolution(5));
            }
            else if (current_phase == 2)
            {
                phase2 = false;
                phase3 = true;
                StartCoroutine(PuzzleSolution(7));
            }
            else if (current_phase == 3)
            {
                disabler.DisableObject();
            }

            NextPhaseSetUp();
        }
        else
        {
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
