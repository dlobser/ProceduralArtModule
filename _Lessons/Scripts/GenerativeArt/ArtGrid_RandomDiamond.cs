using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGrid_RandomDiamond : ArtGrid_BaseClass
{
    public Material material;

    public override void Init()
    {
        float[] randoms = new float[] { Random.Range(.4f,.6f), Random.Range(.4f, .6f), Random.Range(.4f, .6f), Random.Range(.4f, .6f) };
        Vector3[] vecs = {
            new Vector3(-1, 1, 0)*.5f,
            new Vector3(1, 1, 0)*.5f,
            new Vector3(1, -1, 0)*.5f,
            new Vector3(-1, -1, 0)*.5f
                };
        float j = Random.Range(.5f,.8f);
        for (int i = 0; i < 4; i++)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g.transform.parent = this.transform;

            g.GetComponent<MeshRenderer>().material = material;
            SetRandomColor randomColor = g.AddComponent<SetRandomColor>();
            randomColor.SetValues(j, j + .1f, Random.value, 1, 1, 1);
            randomColor.RandomizeColor();

            int k = (i + 1) % 4;
            int l = (i + 2) % 4;
            g.transform.localScale = new Vector3(.1f, .1f, Vector3.Distance(
                                        Vector3.Lerp(vecs[i], vecs[k], randoms[i]),
                                        Vector3.Lerp(vecs[k], vecs[l], randoms[k])));
            g.transform.localPosition = Vector3.Lerp(Vector3.Lerp(vecs[i], vecs[k], randoms[i]),
                                                     Vector3.Lerp(vecs[k], vecs[l], randoms[k]), .5f);
            g.transform.LookAt(Vector3.Lerp(vecs[i], vecs[k], randoms[i]));
            j += .04f;

        }

        GameObject G = GameObject.CreatePrimitive(PrimitiveType.Cube);
        G.transform.parent = this.transform;

        G.GetComponent<MeshRenderer>().material = material;
        SetRandomColor RandomColor = G.AddComponent<SetRandomColor>();
        RandomColor.SetValues(j, j + .1f, Random.value, 1, .5f,.6f);
        RandomColor.RandomizeColor();

        G.transform.localScale = new Vector3(1, 1, .1f);
        G.transform.localPosition = new Vector3(0, 0, .2f);

	}
}
