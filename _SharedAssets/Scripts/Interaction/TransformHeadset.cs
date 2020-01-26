using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHeadset : MonoBehaviour
{
    public Button button;
    public float translateSpeed = 1;
    float tSpeed;
    Vector3 move;
    public float easeSpeed = .01f;
    public float slowDownMultiplier = 5;
    public bool maintainHeight;
    float initHeight;

    void Start()
    {
        move = Vector3.zero;
        initHeight = this.transform.localPosition.y;
    }

    void Update()
    {
        if (button.click > .5f)
        {
            tSpeed = Mathf.Lerp(tSpeed, translateSpeed, easeSpeed);
            this.transform.Translate(Camera.main.transform.forward * tSpeed * Time.deltaTime);
        }
        else if(tSpeed>0){
            tSpeed = Mathf.Lerp(tSpeed, 0, easeSpeed * slowDownMultiplier);
            this.transform.Translate(Camera.main.transform.forward*tSpeed*Time.deltaTime);
        }
        if(maintainHeight){
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0, this.transform.localPosition.z);
        }
    }
}
