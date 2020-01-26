using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_ChooseColor : Interactable
{
    public Color color;
    public string textureToSample = "_MainTex";

    public override void HandleHover()
    {
        if (clicked > .5f)
        {
            Vector2 texHit = gaze.raycastHit.textureCoord;
            Transform o = gaze.raycastHit.transform;
            Texture2D texture = o.GetComponent<MeshRenderer>().material.GetTexture(textureToSample) as Texture2D;
            if (texture.isReadable)
                color = texture.GetPixel((int)(texHit.x * texture.width), (int)(texHit.y * texture.height));
            else
                Debug.LogWarning("texture isn't set to be readable");
        }
    }

}
