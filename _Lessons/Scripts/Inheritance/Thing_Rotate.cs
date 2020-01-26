using UnityEngine;

public class Thing_Rotate : Thing_BaseClass
{
    public override void Trigger()
    {
        this.transform.localEulerAngles += Random.insideUnitSphere*360;
    }
}
