using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField] ObjChecker object1;
    [SerializeField] ObjChecker object2;
    [SerializeField] ObjChecker object3;
    [SerializeField] ObjChecker object4;
    [SerializeField] ObjChecker object5;

    public void PlayObject(int objectnum)
    {
        if (objectnum == 1)
        {
            object1.ParticleDisplay();
        }
        else if (objectnum == 2)
        {
            object2.ParticleDisplay();
        }
        else if (objectnum == 3)
        {
            object3.ParticleDisplay();
        }
        else if (objectnum == 4)
        {
            object4.ParticleDisplay();
        }
        else if (objectnum == 5)
        {
            object5.ParticleDisplay();
        }
        else
        {
            Debug.Log("Particle error");
        }
    }

}
