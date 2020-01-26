using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Example Usage
//Make a cube, move it to 0,0,.5 - scale it to .2,.2,1
//Put it in a null at 0,0,0
//Attach this script to the top null

public class LaserPointer : MonoBehaviour {

    public RaycastHit hit;
    public GameObject endPoint;
    public Button button;
    MeshRenderer[] renderers;

	private void Start()
	{
        renderers = GetComponentsInChildren<MeshRenderer>();
	}

	void Update() {
        if (button == null || button.click > .5f)
        {
            foreach (MeshRenderer m in renderers)
            {
                m.enabled = true;
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                transform.localScale = new Vector3(1, 1, Vector3.Distance(this.transform.position, hit.point));
                if (endPoint != null)
                {
                    endPoint.transform.position = hit.point;
                    endPoint.SetActive(true);
                }

            }
            else
            {
                if(endPoint!=null)
                    endPoint.SetActive(false);
                transform.localScale = new Vector3(1, 1, 100);
            }
        }
        else{
            foreach(MeshRenderer m in renderers){
                m.enabled = false;
            }
        }
    }
}
