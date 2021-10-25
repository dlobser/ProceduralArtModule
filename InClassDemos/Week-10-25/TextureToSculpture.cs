using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureToSculpture : MonoBehaviour
{
    public Texture2D texture2D;
    public int detailX;
    public int detailY;
    public GameObject pixel;

    void Start()
    {
        for (int i = 0; i < texture2D.width ; i+=detailX)
        {
            for (int j = 0; j < texture2D.height; j+=detailY)
            {
                Color c = texture2D.GetPixel(i,j);
                print(c);
                GameObject p = Instantiate(pixel);
                p.transform.localPosition = new Vector3(i/detailX,j/detailY,0);
                p.GetComponent<MeshRenderer>().material.color = c;
            }
        }
    }


    void Update()
    {

    }
}
