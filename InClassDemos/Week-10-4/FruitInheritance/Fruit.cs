using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Color color;
    public float size;
    public float bumpiness;
    public float roughness;
    public bool isBerry;
    public float ripeness;

    public virtual void Eat() { }

}
