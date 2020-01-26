using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 move;
    public Vector3 rotate;

    void Update()
    {
        this.transform.Translate(move*Time.deltaTime);
        this.transform.Rotate(rotate*Time.deltaTime);
    }
}
