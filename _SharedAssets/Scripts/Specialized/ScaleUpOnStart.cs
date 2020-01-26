using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpOnStart : MonoBehaviour
{
    public float speed;
    float counter;
    Vector3 initScale;

    void Awake()
    {
        initScale = this.transform.localScale;
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        if(counter<speed){
            counter += Time.deltaTime;
            this.transform.localScale = Vector3.Lerp(Vector3.zero, initScale, counter / speed);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
}
