using UnityEngine;

public class Simple_Interactable_Color : Simple_Interactable
{
    Color init;
    public Color color;
    bool raycastHit;

	private void Start()
	{
        init = GetComponent<MeshRenderer>().material.color;
	}

	public override void OnRaycastHit(){
        raycastHit = true;
    }

	private void Update()
	{
        if(raycastHit)
            GetComponent<MeshRenderer>().material.color = color;
        else
            GetComponent<MeshRenderer>().material.color = init;
        
        raycastHit = false;
	}
}
