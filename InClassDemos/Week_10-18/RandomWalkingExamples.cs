using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkingExamples : MonoBehaviour
{
    public Vector2 frequency;
    public Vector2 amplitude;
    public Vector2 offset;

    public Vector2 nfrequency;
    public Vector2 namplitude;
    public Vector2 noffset;


    float counter;
    public float counterOffset = .01f;

    public LineRenderer lineRenderer;
    Vector3[] points;

    public int amountOfPoints = 100;

    public bool rebuild;
    public bool writeGCode;

    public GameObject spinner;

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

        //for (int i = 0; i < amountOfPoints; i++)
        //{
        //    counter += counterOffset;
        //    float nx = Mathf.PerlinNoise(nfrequency.x * counter + noffset.x, 0);// * namplitude.x;
        //    float ny = Mathf.PerlinNoise(nfrequency.y * counter + noffset.y, 0);// * namplitude.y;

        //    float n2x = Mathf.PerlinNoise(nx, 0) * namplitude.x;
        //    float n2y = Mathf.PerlinNoise(ny, 0) * namplitude.y;

        //    float x = Mathf.Sin(frequency.x * counter + offset.x) * amplitude.x;
        //    float y = Mathf.Sin(frequency.y * counter + offset.y) * amplitude.y;
        //    Vector3 point = new Vector3(x+nx, (float)i/(float)amountOfPoints, 0);
        //    points[i] = point;
        //}

        //float nx = 0;
        //float ny = 0;

        //for (int i = 0; i < amountOfPoints; i++)
        //{
        //    counter += counterOffset;
        //    nx += (Mathf.PerlinNoise(nfrequency.x * counter + noffset.x, 0)-.5f) * namplitude.x;
        //    ny += (Mathf.PerlinNoise(nfrequency.y * counter + noffset.y, 0)-.5f) * namplitude.y;

        //    Vector3 point = new Vector3(nx, ny, 0);
        //    points[i] = point;
        //}

        //float nx = 0;
        //float ny = 0;

        //for (int i = 0; i < amountOfPoints; i++)
        //{
        //    nx += Random.insideUnitSphere.x * namplitude.x;
        //    ny += Random.insideUnitSphere.y * namplitude.y;

        //    Vector3 point = new Vector3(nx, ny, 0);
        //    points[i] = point;
        //}


        float spin = 0;

        for (int i = 0; i < amountOfPoints; i++)
        {
            spinner.transform.localEulerAngles = new Vector3(0, 0, spin);
            spin += Random.insideUnitSphere.x * namplitude.x;

            Vector3 point = spinner.transform.GetChild(0).position;
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
