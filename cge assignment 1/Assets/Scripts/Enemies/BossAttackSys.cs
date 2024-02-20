using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackSys : MonoBehaviour
{

    [SerializeField] GameObject pf_hfld;
    

    public void SpawnEnemy(string enemyname, Vector2 SpawnPoint)
    {



        if (enemyname == "hfld")
        {
            Instantiate(pf_hfld, SpawnPoint, Quaternion.identity);
        }
        else if (enemyname == "lfhd")
        {

        }
        else if (enemyname == "boomshroom")
        {

        }
        else
        {
            Debug.Log("spawning error");
        }

    }

}
