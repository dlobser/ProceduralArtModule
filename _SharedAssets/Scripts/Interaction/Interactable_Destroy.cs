using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Destroy : Interactable
{

    public GameObject explosion;

    public override void HandleHover()
    {
        GameObject e = Instantiate(explosion);
        e.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

	
}
