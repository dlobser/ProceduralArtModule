using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineTrace : MonoBehaviour
{
    public Transform moveUp;
    public Transform leftAndRight;

    public float frequency;
    public float amplitude;

    public float frequency2;
    public float amplitude2;

    public float moveUpSpeed;

    void Update()
    {
        moveUp.localPosition = new Vector3(
            Mathf.Sin(Time.time*frequency) * amplitude, 
            Time.time * moveUpSpeed, 
            0);

        leftAndRight.localEulerAngles = new Vector3(0, 0, 
            Mathf.Sin(Time.time * frequency2) * amplitude2);

    }
}
