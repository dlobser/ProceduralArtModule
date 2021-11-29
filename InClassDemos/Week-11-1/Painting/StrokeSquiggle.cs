using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeSquiggle : Stroke
{
    public LineRenderer lineRenderer;
    public int detail;
    public int length;
    public float width;
    public float strokeLength;
    // public Vector3 startPoint;
    // public Color color;

    public override void Rebuild(){
        Vector3[] points = new Vector3[length];
        Vector3[] line = new Vector3[detail];

        print(startPoint);
        for (int i = 0; i < points.Length; i++)
        {
            
            if(i==0)
                points[i] = startPoint;
                // print(points[i]);
            else{
                points[i] = points[i-1] + Random.insideUnitSphere * strokeLength;
            }
            
        }

        for (int i = 0; i < line.Length; i++)
        {
            float percent = (float)i/(float)line.Length;
            line[i] = CatmullRomSpline.GetSplinePos(points,percent);
        }

        lineRenderer.positionCount = detail;
        lineRenderer.SetPositions(line);
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.widthMultiplier = width;
    }

    public override void Rebuild(Vector3[] positions, Color[] colors){
                Vector3[] line = new Vector3[detail];

         for (int i = 0; i < line.Length; i++)
        {
            float percent = (float)i/(float)line.Length;
            line[i] = CatmullRomSpline.GetSplinePos(positions,percent);
        }

        lineRenderer.positionCount = detail;
        lineRenderer.SetPositions(line);
        Gradient g = new Gradient();
        GradientColorKey[] keys = new GradientColorKey[colors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            GradientColorKey k = new GradientColorKey();
            k.color = colors[i];
            k.time = (float)i/(float)colors.Length;
            keys[i] = k;
            // print(keys[i].color);
        }
        g.colorKeys = keys;
        lineRenderer.colorGradient = g;
        // lineRenderer.startColor = color;
        // lineRenderer.endColor = color;
        lineRenderer.widthMultiplier = scale;

    }
}
