using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjChecker : MonoBehaviour
{
    [SerializeField] MemoryMaster puzzleMaster;
    [SerializeField] private int object_number;
    [SerializeField] ParticleSystem objectOn;
    [SerializeField] AudioSource sound;

    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && finished == false)
        {
            puzzleMaster.GetObjectNumber(object_number);
        }
    }

    public void ParticleDisplay()
    {
        objectOn.Play();
        sound.Play();
        Invoke("EndParticle", 1.0f);
    }

    private void EndParticle()
    {
        objectOn.Stop();
    }

    public void EndPuzzle()
    {
        finished = true;
    }
}
