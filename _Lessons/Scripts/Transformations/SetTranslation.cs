using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTranslation : MonoBehaviour
{
    public Vector3 objectPosition;
    public Vector3 objectRotation;
    public Vector3 objectScale = Vector3.one;

    public bool useLocalSpace;

    void Update()
    {

        if (useLocalSpace == true)
        {
            this.transform.localPosition = objectPosition;
            this.transform.localEulerAngles = objectRotation;
            this.transform.localScale = objectScale;
        }
        else
        {
            this.transform.position = objectPosition;
            this.transform.eulerAngles = objectRotation;
            this.transform.localScale = objectScale;
        }



    }
}
