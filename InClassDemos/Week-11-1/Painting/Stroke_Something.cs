using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroke_Something : Stroke
{
    public int amount;
    public GameObject thing;
    
    public override void Rebuild(){

        for (int i = 0; i < amount; i++)
        {
            GameObject g = Instantiate(thing,startPoint+ new Vector3(i,0,0),Quaternion.identity,this.transform);
            g.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
