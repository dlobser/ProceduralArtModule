using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGrid_ConcentricSquares : ArtGrid_BaseClass
{
    public Material material;

	public override void Init()
	{
        int rand = Random.Range(1, 10);
        float j = Random.Range(.3f,.5f);
        for (int i = 0; i < rand; i++)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g.transform.parent = this.transform;

            SetRandomColor randomColor = g.AddComponent<SetRandomColor>();
            randomColor.SetValues(j,j+.1f, Random.value, 1, 1, 1);
            randomColor.RandomizeColor();
            g.GetComponent<MeshRenderer>().material = material;
            float size = ((float)i+1) / (float)rand;
            g.transform.localScale = new Vector3(size,size,.1f);
            g.transform.localPosition = new Vector3(0,0,i*.1f);
            g.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-5f, 5f));
            j += .04f;

        }

	}
}
