using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBehavior : MonoBehaviour
{

    public bool rotating;
    public bool moving;
    public bool waiting = true;

    float counter = 0;
    public float rotateSpeed;
    public float moveSpeed;

    Vector3 randomRotation;

    void Update()
    {
        if(waiting && !rotating){
            if(Input.GetKeyDown(KeyCode.A)){
                rotating = true;
            }
        }
        else if(waiting && rotating){
            randomRotation = Random.insideUnitSphere * 360;
            waiting = false;
            print(randomRotation);
        }
        else if(!waiting && rotating){
            this.transform.Rotate(randomRotation * Time.deltaTime * rotateSpeed);
            counter += Time.deltaTime;
            if(counter>1){
                counter = 0;
                rotating = false;
                moving = true;
            }
        }
        else if(moving){
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            counter += Time.deltaTime;
            if (counter > 1)
            {
                counter = 0;
                moving = false;
                waiting = true;
            }
        }
    }
}
