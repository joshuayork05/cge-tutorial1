using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjChecker : MonoBehaviour
{
    [SerializeField] MemoryMaster puzzleMaster;
    [SerializeField] private int object_number;
    [SerializeField] ParticleSystem objectOn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        puzzleMaster.GetObjectNumber(object_number);
    }

    public void ParticleDisplay()
    {
        objectOn.Play();
        Debug.Log("Start");
        Invoke("EndParticle", 1.0f);
        Debug.Log("End pt1");
    }

    private void EndParticle()
    {
        Debug.Log("End pt2");
        objectOn.Stop();
    }
}
