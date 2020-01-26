using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Reticle : Interactable
{
    public GameObject reticle;
    GameObject thisReticle;
    public Interactable interactable;
    bool interactableTriggered = false;

	public override void HandleHover(){
		base.HandleHover();

        if (thisReticle == null){
            thisReticle = Instantiate(reticle,this.transform);
        }

        if(!interactableTriggered&&hoverCounter>=hoverTime){
            if(interactable!=null)
                interactable.HandleTrigger();
            interactableTriggered = true;
        }

        thisReticle.transform.position = Camera.main.transform.position;
        thisReticle.transform.LookAt(this.transform.position);
        thisReticle.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Percent",( hoverCounter / hoverTime)); 
	}

	public override void HandleWaiting(){
		base.HandleWaiting();
        if (thisReticle != null)
        {
            if (hoverCounter > 0)
            {
                thisReticle.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetFloat("_Percent",(hoverCounter / hoverTime));
            }
            else
                Destroy(thisReticle);
        }
	}

}
