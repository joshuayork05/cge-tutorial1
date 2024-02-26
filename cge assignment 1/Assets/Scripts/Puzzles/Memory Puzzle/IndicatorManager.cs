using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField] ObjChecker[] MemoryObjects;


    public void PlayObject(int objectnum)
    {
        if (objectnum == 1)
        {
            MemoryObjects[0].ParticleDisplay();
        }
        else if (objectnum == 2)
        {
            MemoryObjects[1].ParticleDisplay();
        }
        else if (objectnum == 3)
        {
            MemoryObjects[2].ParticleDisplay();
        }
        else if (objectnum == 4)
        {
            MemoryObjects[3].ParticleDisplay();
        }
        else if (objectnum == 5)
        {
            MemoryObjects[4].ParticleDisplay();
        }
        else
        {
            Debug.Log("Particle error");
        }
    }

    public void EndPuzzle()
    {
        foreach (var memObject in MemoryObjects) 
        {
            memObject.EndPuzzle();
        }
    }

}
