using UnityEngine;
using Art;

/*
 * This script instantiates an object and randomly positions, scales and colors the clones
 * It parents the items to the root object
 * so that they will be destroyed when 'rebuild' is true
 */

public class ArtSquareEvenSimpler : ArtMakerTemplate
{
    //assign this in the editor
    public GameObject shape;

    public override void MakeArt()
    {
        for (int i = 0; i < 10; i++)
        {
            //Create a new gameObject variable and assign a clone of our shape
            GameObject g = Instantiate(shape);
            //parent to the 'root' object so that everytime you tap 'r' it will properly destroy and refresh
            g.transform.parent = root.transform;
            //Your 'shape' must have a meshrenderer or this script will give an error
            g.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            //a vector * a float returns a vector
            g.transform.localScale = Vector3.one * Random.value;
            //insideUnitSphere returns a random point inside or on a sphere with radius 1.0 (Read Only).
            g.transform.position = Random.insideUnitSphere;
            //if we multiply that by 360 we get a random angle for each x,y,z axis from -360 to 360
            g.transform.localEulerAngles = Random.insideUnitSphere * 360;
        }
    }
}
