using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_weapon : MonoBehaviour //class_name inherits from class2
{
    public void Start()
    {
        attack();
    }

    public void attack()
    {
        int damage = 10;

        Debug.Log($"Basic attack: {damage}", this);//the 'this' says where this line was called from/originated from
    }
}
