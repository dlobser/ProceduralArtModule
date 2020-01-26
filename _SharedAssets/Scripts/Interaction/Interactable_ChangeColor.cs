using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_ChangeColor : Interactable
{
    public Color color;
    Color oldColor;

	public override void HandleStart()
	{
		base.HandleStart();
        SetOldColor();
	}

	public override void HandleHover()
	{
        base.HandleHover();
        if(hoverCounter<hoverTime)
            SetColor(Color.Lerp(oldColor, color, hoverCounter/hoverTime));

	}

	public override void HandleWaiting()
	{
        base.HandleWaiting();

        if (hoverCounter > 0)
        {
            SetColor(Color.Lerp(oldColor, color, hoverCounter));
        }
        if (debug)
            Debug.Log(Color.Lerp(oldColor, color, hoverCounter));

	}

	private void OnApplicationQuit()
	{
        SetColor(oldColor);
	}

    void SetOldColor(){
        if (this.GetComponent<MeshRenderer>() != null)
            oldColor = this.GetComponent<MeshRenderer>().material.color;
        else if (this.GetComponent<SpriteRenderer>() != null)
            oldColor = this.GetComponent<SpriteRenderer>().color;

    }

    void SetColor(Color color){
        if (this.GetComponent<MeshRenderer>() != null)
            this.GetComponent<MeshRenderer>().material.color = color;
        else if (this.GetComponent<SpriteRenderer>() != null)
            this.GetComponent<SpriteRenderer>().color = color;
    }
}
