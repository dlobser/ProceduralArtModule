using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeFunctions : MonoBehaviour
{
    LineRenderer line;
    public int detail;
    public float frequency;
    public float amplitude;
    public float offset;
    public float permuteSpeed;

    public float frequency2;
    public float amplitude2;
    public float offset2;

    void Start()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.positionCount = detail;

    }

    void Update()
    {
        for (int i = 0; i < detail; i++)
        {
            //line.SetPosition(i, new Vector3(i, Mathf.Sin(i*frequency+offset)*amplitude +50, 0));
            float noise = Mathf.PerlinNoise(frequency * i + offset, Time.time * permuteSpeed) * amplitude;
            float noise2 = Mathf.PerlinNoise(noise + frequency2 * i + offset2, Time.time * permuteSpeed) * amplitude2;
            line.SetPosition(i, new Vector3(i, noise2 + 50, 0));
        }
    }
}
