using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MandalaLine : MonoBehaviour
{

    public Vector2 frequency;
    public Vector2 amplitude;
    public Vector2 offset;
    public Vector2 posOffset;
    public float noiseCenter = .5f;

    public GameObject center;

    float counter;
    public float counterOffset = .01f;

    public LineRenderer lineRenderer;

    List<Vector3[]> points;
    List<Vector3> symmetricalPoints;

    public int amountOfPoints = 100;

    public bool rebuild;
    public bool writeGCode;

    public Vector3 minInputSize;
    public Vector3 maxInputSize;

    public Vector3 minOutputSize;
    public Vector3 maxOutputSize;

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
        points = new List<Vector3[]>();
        symmetricalPoints = new List<Vector3>();
        for (int j = 0; j < 1; j++)
        {
            points.Add(new Vector3[amountOfPoints]);

            float x = 0; 
            float y = 0;
            for (int i = 0; i < amountOfPoints; i++)
            {
                counter += counterOffset;
                x = (Mathf.PerlinNoise(frequency.x * counter + offset.x,0)-noiseCenter) * amplitude.x;
                y = (Mathf.PerlinNoise(frequency.y * counter + offset.y,0)-noiseCenter) * amplitude.y;
                Vector3 point = new Vector3(x, y, 0) + new Vector3(posOffset.x,posOffset.y,0);
                points[j][i] = point;
            }

            for (int k = 0; k < amountOfPoints; k++)
            {
                symmetricalPoints.Add(points[j][k]);
            }
            symmetricalPoints.Add(points[j][points[j].Length-1] + new Vector3(0, 0, 1));
            symmetricalPoints.Add(Vector3.Scale(points[j][0], new Vector3(1, -1, 1) ) + new Vector3(0,0,1));
            for (int k = 0; k < amountOfPoints; k++)
            {
                symmetricalPoints.Add(Vector3.Scale(points[j][k], new Vector3(1, -1, 1)));
            }

            symmetricalPoints.Add(Vector3.Scale(points[j][points[j].Length - 1], new Vector3(1, -1, 1)) + new Vector3(0, 0, 1));
            symmetricalPoints.Add(Vector3.Scale(points[j][0], new Vector3(-1, 1, 1)) + new Vector3(0, 0, 1));

            for (int k = 0; k < amountOfPoints; k++)
            {
                symmetricalPoints.Add(Vector3.Scale(points[j][k], new Vector3(-1, 1, 1)));
            }

            symmetricalPoints.Add(Vector3.Scale(points[j][points[j].Length - 1], new Vector3(-1, 1, 1)) + new Vector3(0, 0, 1));
            symmetricalPoints.Add(Vector3.Scale(points[j][0], new Vector3(-1, -1, 1)) + new Vector3(0, 0, 1));

            for (int k = 0; k < amountOfPoints; k++)
            {
                symmetricalPoints.Add(Vector3.Scale(points[j][k], new Vector3(-1,-1,1)));
            }

        }

        lineRenderer.positionCount = symmetricalPoints.Count;
        lineRenderer.SetPositions(symmetricalPoints.ToArray());

    }

    void WriteGCode()
    {
        string header = "M82 ;absolute extrusion mode\n; Ender 3 Custom Start G-code\nG92 E0 ; Reset Extruder\nG28 ; Home all axes\nM107 ; Fan off\nG0 F0 X0 Y0\n";
        string positions = "";

        for (int i = 0; i < symmetricalPoints.Count; i++)
        {
            positions += 
                "G0 X" +
            map(symmetricalPoints[i].x,minInputSize.x,maxInputSize.x,minOutputSize.x,maxOutputSize.x)
                + " Y" +
            map(symmetricalPoints[i].y, minInputSize.y, maxInputSize.y, minOutputSize.y, maxOutputSize.y)
                + " Z" +
            map(symmetricalPoints[i].z, minInputSize.z, maxInputSize.z, minOutputSize.z, maxOutputSize.z)
                + "\n";
        }
        header += positions;

        string path = "Assets/Drawing.gcode";
        File.AppendAllText(path, header );
        print(header);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

}


