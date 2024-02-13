using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    [SerializeField] private SpecificOrderMaster objectmaster;
    [SerializeField] private int objNum;
    [SerializeField] ParticleSystem objectOn;

    private bool particleActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeParticleState();
        objectmaster.CheckObjects(objNum);
    }

    public void ChangeParticleState()
    {
        if (particleActive)
        {
            particleActive = !particleActive;
            objectOn.Stop();
        }
        else
        {
            particleActive = !particleActive;
            objectOn.Play();
        }
    }

    public void SetParticleActive(bool state)
    {
        particleActive = !state;
        ChangeParticleState();
    }
}
