using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnotherObject : MonoBehaviour
{
    public Transform otherObject;
    public Vector3 move;
    public Vector3 rotate;

    void Update()
    {
        otherObject.Translate(move*Time.deltaTime);
        otherObject.Rotate(rotate*Time.deltaTime);
    }
}
