using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Art;

public class WalkerWithSeparateLines : MonoBehaviour
{
    List<Vector3> points;
    float x;
    float y;
    public LineRenderer lineRenderer;

    void Start()
    {
        points = new List<Vector3>();

        for (int i = 0; i < 5; i++)
        {

            x = 0;
            y = 0;

            for (int j = 0; j < 500; j++)
            {
                x += Random.Range(-1f, 1f);
                y += Random.Range(-1f, 1f);
                if (x > 100)
                    x = 100;
                if (y > 100)
                    y = 100;
                if (x < -100)
                    x = -100;
                if (y < -100)
                    y = -100;

                Vector3 v = new Vector3(x, y, 0);
                points.Add(v);
            }

            Vector3 v2 = points[points.Count - 1] + new Vector3(0,0,10);
            points.Add(v2);
            v2 = new Vector3(0, 0, 10);
            points.Add(v2);
        }

        lineRenderer.positionCount = points.Count;
        Vector3[] displayPoints = points.ToArray();
        lineRenderer.SetPositions(displayPoints);
        WriteGCode.Write(displayPoints);
    }

}
