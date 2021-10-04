using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Art;

public class ArtMakerTest : ArtMakerTemplate
{
    [TextArea]
    public string MyTextArea;

    public GameObject objectToInstantiate;

    public override void MakeArt()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject g = Instantiate(objectToInstantiate);
            g.transform.localPosition = Random.insideUnitSphere * 5;
            AddToRoot(g.transform);
        }
    }
}
