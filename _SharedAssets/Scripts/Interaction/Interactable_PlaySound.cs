using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_PlaySound : Interactable
{
    public AudioSource sound;
    public float randomizePitch = 0;

	public override void HandleEnter()
	{
        base.HandleEnter();
        sound.pitch = Random.Range(1 - randomizePitch, 1 + randomizePitch);
        sound.Play();
	}
}