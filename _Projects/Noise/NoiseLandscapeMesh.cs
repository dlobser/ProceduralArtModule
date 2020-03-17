using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseLandscapeMesh : MonoBehaviour
{
    public int uDivs = 10;
    public int vDivs = 10;

    public Vector2 frequency;
    public float amplitude;
    public Vector2 offset;

    public bool rebuild;

    public float floor;
    public float ceiling;

    void Start()
    {
        
    }

    void Build()
    {
        GetComponent<MeshFilter>().mesh = Grid.Generate(uDivs, vDivs, Plane);
        GetComponent<MeshFilter>().mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh.RecalculateTangents();
    }

    Vector3 Plane(float u, float v)
    {
        float noise = Mathf.PerlinNoise(
                frequency.x * u + offset.x,
                frequency.y * v + offset.y) * amplitude;

        noise = Mathf.Max(floor, noise);
        noise = Mathf.Min(ceiling, noise);
        
        return new Vector3(u, noise, v);
    }

    void Update()
    {
        if (rebuild)
        {
            Destroy(GetComponent<MeshFilter>().mesh);
            Build();
            //rebuild = false;
        }
    }
}
