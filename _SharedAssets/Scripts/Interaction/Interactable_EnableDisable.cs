using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_EnableDisable : Interactable
{
    public GameObject[] enable;
    public GameObject[] disable;

	public override void HandleExit()
	{
        foreach (GameObject g in enable)
            g.SetActive(false);
        foreach (GameObject g in disable)
            g.SetActive(true);
	}

	public override void HandleEnter()
	{
        foreach (GameObject g in enable)
            g.SetActive(true);
        foreach (GameObject g in disable)
            g.SetActive(false);
	}
}
