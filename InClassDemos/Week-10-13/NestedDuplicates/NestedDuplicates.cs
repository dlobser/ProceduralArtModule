using UnityEngine;
using Art;

/*
 * This script instantiates an object and randomly positions, scales and colors the clones
 * It parents the items to the root object
 * so that they will be destroyed when 'rebuild' is true
 */

public class NestedDuplicates : ArtMakerTemplate
{
    //assign this in the editor
    public GameObject shape;

    public int childAmount;
    public int parentAmount;
    public float childSpread;
    public float parentSpread;

    public override void MakeArt()
    {
        for (int i = 0; i < parentAmount; i++)
        {
            GameObject parentObject = new GameObject("NestedParent");
            parentObject.transform.parent = root.transform;

            for (int j = 0; j < childAmount; j++)
            {
                GameObject g = Instantiate(shape);
                g.transform.parent = parentObject.transform;
                g.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                g.transform.localScale = Vector3.one * Random.value;
                g.transform.localPosition = new Vector3(j * childSpread, 0, 0);
                g.transform.localEulerAngles = Random.insideUnitSphere * 360;
            }

            parentObject.transform.localScale = Vector3.one * Random.value;
            parentObject.transform.localPosition = Random.insideUnitSphere * parentSpread;
            parentObject.transform.localEulerAngles = Random.insideUnitSphere * 360;

        }
    }
}
