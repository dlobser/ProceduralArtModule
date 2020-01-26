using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_Controller : MonoBehaviour {

    public bool rightHand;
    public bool debug;
    Vector3 prev;
    public float speed { get; set; }

    void Start () {
		string[] names = Input.GetJoystickNames();
        foreach (string n in names) {
            if(debug)
                Debug.Log(n);
        }
    }

    void Update () {
        
        #pragma warning disable 0618

        if (rightHand) {
            this.transform.position = InputTracking.GetLocalPosition(XRNode.RightHand);
            this.transform.rotation = InputTracking.GetLocalRotation(XRNode.RightHand);
        }
        else {
            this.transform.position = InputTracking.GetLocalPosition(XRNode.LeftHand);
            this.transform.rotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
        }

        #pragma warning restore 0618

        speed = Mathf.Lerp(speed, Vector3.Distance(prev, this.transform.position), .6f);
        prev = this.transform.position;
    }
   

}
