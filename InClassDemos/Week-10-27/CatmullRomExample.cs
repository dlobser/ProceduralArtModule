using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatmullRomExample : MonoBehaviour
{
    public Transform[] transforms;
    public LineRenderer line;
    public int detail;
    GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        root = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(root!=null)
        {
            Destroy(root);
        }
        root = new GameObject();
        line.positionCount = detail;
        Vector3[] points = new Vector3[detail];
        for (int i = 0; i < detail; i++)
        {
            GameObject g = Instantiate(transforms[0].gameObject);
            g.transform.parent = root.transform;
            points[i] = CatmullRomSpline.GetSplinePos(transforms,(float)i/100f);
            g.transform.position = points[i];
        }
        line.SetPositions(points);
    }
}
