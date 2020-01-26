using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckControl : MonoBehaviour
{
    public TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float size = Input.GetAxis("RTriggerPress") + 1;
        this.transform.localScale = new Vector3(size, size, size);
        textMesh.text = size + "";
    }
}
