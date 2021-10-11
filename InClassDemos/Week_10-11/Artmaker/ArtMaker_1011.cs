using UnityEngine;
using Art;

/*
 * This script instantiates an object and randomly positions, scales and colors the clones
 * It parents the items to the root object
 * so that they will be destroyed when 'rebuild' is true
 */

public class ArtMaker_1011 : ArtMakerTemplate
{
    //assign this in the editor
    public GameObject shape;
    public float forestSize;
    public int treeAmount;

    public override void MakeArt()
    {
        for (int i = 0; i < treeAmount; i++)
        {
            //Create a new gameObject variable and assign a clone of our shape
            GameObject g = Instantiate( shape, root.transform);

            //Your 'shape' must have a meshrenderer or this script will give an error
            if(g.GetComponent<MeshRenderer>()!=null)
                g.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

            Transform trunk = g.transform.GetChild(0).GetChild(0);
            trunk.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

            Transform leaves = g.transform.GetChild(1).GetChild(0);
            leaves.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();


            //a vector * a float returns a vector
            g.transform.localScale = Vector3.one * Random.value;
            //insideUnitSphere returns a random point inside or on a sphere with radius 1.0 (Read Only).

            Vector3 pos = Random.insideUnitSphere * forestSize;
            g.transform.position = new Vector3(pos.x, 0, pos.z);

            //if we multiply that by 360 we get a random angle for each x,y,z axis from -360 to 360
            //g.transform.localEulerAngles = Random.insideUnitSphere * 360;
        }
    }
}
