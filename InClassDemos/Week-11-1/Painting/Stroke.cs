using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroke : MonoBehaviour
{
    public Color color;
    public Vector3 startPoint;
    public float scale;
    public virtual void Rebuild(){}
    public virtual void Rebuild(Vector3[] positions, Color[] colors){}


}
