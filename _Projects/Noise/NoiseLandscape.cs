using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseLandscape : MonoBehaviour
{
    public GameObject tile;
    public Vector2 frequency;
    public float amplitude;
    public Vector2 offset;

    GameObject root;
    public int detail;

    void Start()
    {
        root = new GameObject("Root");
        for (int i = 0; i < detail; i++)
        {
            for (int j = 0; j < detail; j++)
            {
                GameObject g = Instantiate(tile);
                g.transform.position = new Vector3(i, 0, j);
                g.transform.parent = root.transform;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < root.transform.childCount; i++)
        {
            Vector3 position = root.transform.GetChild(i).position;
            float noise = Mathf.PerlinNoise(
                frequency.x * position.x + offset.x,
                frequency.y * position.z + offset.y) * amplitude;
            root.transform.GetChild(i).transform.localScale = new Vector3(1, noise, 1);

        }
    }
}
