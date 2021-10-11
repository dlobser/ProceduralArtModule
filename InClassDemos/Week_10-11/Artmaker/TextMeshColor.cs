using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshColor : MonoBehaviour
{
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<TextMesh>() != null)
            GetComponent<TextMesh>().color = color;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = color;
    }
}
