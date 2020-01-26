using UnityEngine;

public class Thing_Move : Thing_BaseClass
{ 
    public override void Trigger(){
        this.transform.localPosition += Random.insideUnitSphere;
    }
}
