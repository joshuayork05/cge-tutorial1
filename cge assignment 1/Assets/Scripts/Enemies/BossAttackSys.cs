using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossAttackSys : MonoBehaviour
{
    [SerializeField] GameObject[] Phase2Enemies;
    [SerializeField] GameObject[] Phase3Enemies;
    [SerializeField] GameObject[] Phase4Enemies;

    enum Phase
    {
        Phase1, 
        Phase2, 
        Phase3, 
        Phase4
    }

    Phase current_phase = Phase.Phase1;

    public void UpdatePhase(int phase_num)
    {
        switch (phase_num)
        {
            case 1:
                current_phase = Phase.Phase1;
                break;
            case 2:
                current_phase = Phase.Phase2;
                break;
            case 3:
                current_phase = Phase.Phase3;
                break;
            case 4:
                current_phase = Phase.Phase4;
                break;
        }
    }

    public void ActivateEnemies()
    {
        switch (current_phase)
        {
            case Phase.Phase2:
                for (int i = 0; i < Phase2Enemies.Length; i++)
                {
                    Phase2Enemies[i].SetActive(true);
                }
                break;
            
            case Phase.Phase3:
                for (int i = 0; i < Phase3Enemies.Length; i++)
                {
                    Phase3Enemies[i].SetActive(true);
                }
                break;
            
            case Phase.Phase4:
                for (int i = 0; i < Phase4Enemies.Length; i++)
                {
                    Phase4Enemies[i].SetActive(true);
                }
                break;
        }
        
    }

    public bool CheckEnemyStates()
    {
        int dead_count = 0;
        switch (current_phase) 
        {
            case Phase.Phase2:
                for (int i = 0; i < Phase2Enemies.Length; i++)
                {
                    if (Phase2Enemies[i].activeInHierarchy == false)
                    {
                        dead_count++;
                    }
                }
                if (dead_count == Phase2Enemies.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
            case Phase.Phase3:
                for (int i = 0; i < Phase3Enemies.Length; i++)
                {
                    if (Phase3Enemies[i].activeSelf == false)
                    {
                        dead_count++;
                    }
                }
                if (dead_count == Phase3Enemies.Length)
                {
                    return true;
                }
                else
                {
                    dead_count = 0;
                    return false;
                }
            
            case Phase.Phase4:
                for (int i = 0; i < Phase4Enemies.Length; i++)
                {
                    if (Phase4Enemies[i].activeSelf == false)
                    {
                        dead_count++;
                    }
                }
                if (dead_count == Phase4Enemies.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        
        }

        //added because "all code paths need a return value" - this won't be used.
        return false;
    }
}
