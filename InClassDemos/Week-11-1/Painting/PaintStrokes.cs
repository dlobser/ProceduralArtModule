using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Art;

public class PaintStrokes : ArtMakerTemplate
{
    public Texture2D texture2D;
    public int detailX;
    public int detailY;
    public float scaleMin;
    public float scaleMax;
    public GameObject pixel;

    public override void MakeArt()
    {
        for (int i = 0; i < texture2D.width ; i+=detailX)
        {
            for (int j = 0; j < texture2D.height; j+=detailY)
            {
                int x = (int)(Random.value*texture2D.width);
                int y = (int)(Random.value*texture2D.height);
                Color c = texture2D.GetPixel(x,y);
                c.a = .5f;
                GameObject p = Instantiate(pixel.transform.GetChild(Random.Range(0,pixel.transform.childCount))).gameObject;
                p.transform.localPosition = new Vector3(x,y,0);
                p.GetComponent<SpriteRenderer>().material.color = c;
                p.GetComponent<SpriteRenderer>().sortingOrder = i + j * texture2D.width;
                float value = (c.r+c.r+c.b+c.g+c.g+c.g)/6f;
                float scale = (scaleMax-scaleMin)*value;
                scale += scaleMin;
                scale = Mathf.Max(0,scale);
                p.transform.localScale = Vector3.one*scale;
                p.transform.localEulerAngles = Vector3.forward*Random.value*360;
                AddToRoot(p.transform);
            }
        }
    }


    void Update()
    {

    }
}
