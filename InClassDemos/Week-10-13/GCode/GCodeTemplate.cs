using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Art;

public class GCodeTemplate : ArtMakerTemplate
{
    [Header("Control the sine wave")]
    public Vector2 minFrequency;
    public Vector2 maxFrequency;
    public float counterOffset = .01f;

    Vector3[] points;
    float counter;

    [Space]
    [Header("Line details")]

    public int amountOfPoints = 100;
    public float lineWidth;

    [Space]
    [Header("GCode output")]

    public bool writeGCode;

    public Vector3 minInputSize;
    public Vector3 maxInputSize;

    public Vector3 minOutputSize;
    public Vector3 maxOutputSize;

    void Update()
    {
        if (writeGCode)
        {
            WriteGCode.Write(points, minInputSize, maxInputSize, minOutputSize, maxOutputSize);
            writeGCode = false;
        }
    }

    public override void MakeArt()
    {
        DrawLine();
        if (writeGCode)
            WriteGCode.Write(points,minInputSize,maxInputSize,minOutputSize,maxOutputSize);
    }

    void DrawLine()
    {
        //Instead of time we're making our own counter for mathf.sin
        counter = 0;

        //initialize an array of points, this will recreate the array every time
        points = new Vector3[amountOfPoints];

        //create a new gameobject and assign a linerenderer, 
        //we could also make a public gameobject variable that has a linerenderer attached, 
        //but this allows us to keep everything in code
        GameObject line = new GameObject("Line");
        AddToRoot(line.transform);
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = Color.black;

        //I want the frequency to be the same throughout so set the random values outside the loop
        //see what happens when you put this randomization inside the loop
        Vector2 frequency = new Vector2(Random.Range(minFrequency.x, maxFrequency.x),
            Random.Range(minFrequency.y, maxFrequency.y));

        for (int i = 0; i < amountOfPoints; i++)
        {
            //offset the counter then generate the lissajous
            counter += counterOffset;
            float x = Mathf.Sin(frequency.x * counter);
            float y = Mathf.Sin(frequency.y * counter);

            //x = WriteGCode.map(x, minInputSize.x, maxInputSize.x, minOutputSize.x, maxOutputSize.x);
            //y = WriteGCode.map(y, minInputSize.y, maxInputSize.y, minOutputSize.y, maxOutputSize.y);

            //create a point variable with those values
            Vector3 point = new Vector3(x, y, 0);
            //assign that variable to the array
            points[i] = point;
        }

        //use that array to set the points of the linerenderer
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }


}
