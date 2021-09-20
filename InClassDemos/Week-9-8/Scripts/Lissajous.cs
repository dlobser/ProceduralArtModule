using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lissajous : MonoBehaviour
{
    public float counterX;
    public float counterY;
    public float SpeedX;
    public float SpeedY;

    public float spiral;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        print("Start using print");
    }

    // Update is called once per frame
    void Update()
    {
        counterX += SpeedX;
        counterY += SpeedY;

        this.transform.position = new Vector3(
        Mathf.Sin(counterX) + Mathf.Sin(counterY)*spiral, Mathf.Cos(counterX) + Mathf.Cos(counterY)*spiral, 0);

    }
}
