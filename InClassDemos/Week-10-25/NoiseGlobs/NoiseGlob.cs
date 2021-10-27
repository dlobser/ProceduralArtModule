using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGlob : MonoBehaviour
{
    public GameObject juice;
    public float scale;
    //Every element inside glob should have a single parent

    public void Rebuild(){

        GameObject thisJuice = Instantiate(juice, this.transform);
        thisJuice.transform.localPosition = Vector3.zero;
        thisJuice.transform.localScale = new Vector3(1,1,scale);

    }
}
