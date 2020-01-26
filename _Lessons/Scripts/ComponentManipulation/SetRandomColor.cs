using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomColor : MonoBehaviour
{
    public float minHue;
    public float maxHue;
    public float minSaturation;
    public float maxSaturation;
    public float minValue;
    public float maxValue;

    void Start()
    {
        RandomizeColor();
    }

    public void RandomizeColor(){
        Color color = Color.HSVToRGB(
            Random.Range(minHue, maxHue),
            Random.Range(minSaturation, maxSaturation),
            Random.Range(minValue, maxValue));
        this.GetComponent<MeshRenderer>().material.color = color;
    }

    public void SetValues(float myMinHue, float myMaxHue, float myMinSaturation, float myMaxSaturation, float myMinValue, float myMaxValue)
    {
        minHue = myMinHue;
        maxHue = myMaxHue;
        minSaturation = myMinSaturation;
        maxSaturation = myMaxSaturation;
        minValue = myMinValue;
        maxValue = myMaxValue;
    }

}
