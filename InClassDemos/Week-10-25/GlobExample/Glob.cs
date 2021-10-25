using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glob : MonoBehaviour
{
    public GameObject juice;
    public int amount;

    //Every element inside glob should have a single parent

    public void Rebuild(){
        for (int i = 0; i < amount; i++)
        {
            GameObject thisJuice = Instantiate(juice, this.transform);
            thisJuice.transform.localPosition = Random.insideUnitSphere;
        }
    }
}
