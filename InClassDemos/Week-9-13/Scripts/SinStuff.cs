using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinStuff : MonoBehaviour
{

    public Vector3 frequency;
    public Vector3 amplitude;
    public Vector3 offset;

    public bool move;
    public bool rotate;
    public bool size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(frequency.x * Time.time + offset.x) * amplitude.x ;
        float y = Mathf.Sin(frequency.y * Time.time + offset.y) * amplitude.y ;
        float z = Mathf.Sin(frequency.z * Time.time + offset.z) * amplitude.z ;

        Vector3 sinVector = new Vector3(x, y, z);

        if (move)
            this.transform.localPosition = sinVector;

        if(rotate)
            this.transform.localEulerAngles = sinVector;

        if(size)
            this.transform.localScale = sinVector;
    }
}
