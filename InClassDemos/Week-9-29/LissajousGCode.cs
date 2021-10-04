using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LissajousGCode : MonoBehaviour
{
    public Vector2 frequency;
    public Vector2 amplitude;
    public Vector2 offset;

    float counter;
    public float counterOffset = .01f;

    public LineRenderer lineRenderer;
    Vector3[] points;

    public int amountOfPoints = 100;

    public bool rebuild;
    public bool writeGCode;

    void Start()
    {
    }

    void Update()
    {
        if (rebuild)
        {
            DrawLine();
            //rebuild = false;
        }
        if (writeGCode)
        {
            WriteGCode();
            writeGCode = false;
        }
    }

    void DrawLine()
    {
        counter = 0;
        points = new Vector3[amountOfPoints];

        for (int i = 0; i < amountOfPoints; i++)
        {
            counter += counterOffset;
            float x = Mathf.Sin(frequency.x * counter + offset.x) * amplitude.x;
            float y = Mathf.Sin(frequency.y * counter + offset.y) * amplitude.y;
            Vector3 point = new Vector3(x, y, 0);
            points[i] = point;
        }
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);

    }

    void WriteGCode()
    {
        string header = "M82 ;absolute extrusion mode\n; Ender 3 Custom Start G-code\nG92 E0 ; Reset Extruder\nG28 ; Home all axes\nM107 ; Fan off\nG0 F0 X0 Y0\n";
        string positions = "";

        for (int i = 0; i < amountOfPoints; i++)
        {
            positions += "G0 X" + 
            (((points[i].x + 1) * .5f) * 220)
                + " Y" +
            (((points[i].y + 1) * .5f) * 220)
                + "\n";
        }
        header += positions;
        print(header);
    }
}
