using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDemo_913 : MonoBehaviour
{

    public bool worldSpace;
    public bool moving;
    public bool useMethods;
    public bool localAxis;
    //public bool useSin;

    public Vector3 position;
    public Vector3 eulerAngles;
    public Vector3 scale;

    public Vector3 move;
    public Vector3 rotate;
    public Vector3 size;

    public Vector3 frequency;
    public Vector3 amplitude;
    public Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        if (!moving)
        {
            if (worldSpace)
            {
                this.transform.position = position;
                this.transform.eulerAngles = eulerAngles;
            }

            else //localSpace
            {
                this.transform.localPosition = position;
                this.transform.localEulerAngles = eulerAngles;
                this.transform.localScale = scale;
            }
        }
        else
        {
            if (useMethods)
            {
                if (localAxis)
                {
                    this.transform.Translate(move);
                    this.transform.Rotate(rotate);
                }
                else
                {
                    this.transform.Translate(this.transform.forward * move.z);
                    this.transform.Rotate(rotate);

                }
            }
            else
            {
                float x = Mathf.Sin(frequency.x * Time.time) * amplitude.x;
                float y = Mathf.Sin(frequency.y * Time.time) * amplitude.y;
                float z = Mathf.Sin(frequency.z * Time.time) * amplitude.z;

                Vector3 sinVector = new Vector3(x, y, z);

                this.transform.localPosition += move + sinVector;
                this.transform.localEulerAngles += rotate + sinVector;
                this.transform.localScale += size;
            }
        }

    }
}
