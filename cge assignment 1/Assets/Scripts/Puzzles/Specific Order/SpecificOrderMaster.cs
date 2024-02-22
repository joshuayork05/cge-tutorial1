using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificOrderMaster : MonoBehaviour
{
    [SerializeField] ObjectChecker obj1;
    [SerializeField] ObjectChecker obj2;
    [SerializeField] ObjectChecker obj3;
    [SerializeField] ObjectChecker obj4;
    [SerializeField] ObjectChecker obj5;
    [SerializeField] Disabler disabler;

    private bool object1 = false;
    private bool object2 = false;
    private bool object3 = false;
    private bool object4 = false;
    private bool object5 = false;


    public void CheckObjects(int currentObject)
    {
        if (currentObject == 1)
        {
            Option1();
        }
        else if (currentObject == 2)
        {
            Option2();
        }
        else if(currentObject == 3)
        {
            Option3();
        }
        else if(currentObject == 4)
        {
            Option4();
        }
        else if(currentObject == 5)
        {
            Option5();
        }

        FinalSolutionChecker();
    }


    private void Option1()
    {
        object1 = true; obj1.SetParticleActive(true);
        object2 = true; obj2.SetParticleActive(true);
        object3 = true; obj3.SetParticleActive(true);

        object4 = false; obj4.SetParticleActive(false);
        object5 = false; obj5.SetParticleActive(false);
    }

    private void Option2()
    {
        object1 = true; obj1.SetParticleActive(true);
        object2 = true; obj2.SetParticleActive(true);
        object3 = true; obj3.SetParticleActive(true);

        object4 = false; obj4.SetParticleActive(false);
        object5 = false; obj5.SetParticleActive(false);
    }

    private void Option3()
    {
        object1 = true; obj1.SetParticleActive(true);
        object3 = true; obj3.SetParticleActive(true);
        object4 = true; obj4.SetParticleActive(true);

        object2 = false; obj2.SetParticleActive(false);
        object5 = false; obj5.SetParticleActive(false);
    }

    private void Option4()
    {
        object1 = true; obj1.SetParticleActive(true);
        object4 = true; obj4.SetParticleActive(true);
        object5 = true; obj5.SetParticleActive(true);

        object2 = false; obj2.SetParticleActive(false);
        object3 = false; obj3.SetParticleActive(false);
    }

    private void Option5()
    {
        object2 = true; obj2.SetParticleActive(true);
        object3 = true; obj3.SetParticleActive(true);
        object5 = true; obj5.SetParticleActive(true);
    }

    private void FinalSolutionChecker()
    {
        if (object1 == true && object2 == true && object3 == true && object4 == true && object5 == true)
        {
            disabler.DisableObject();
        }
    }
}
