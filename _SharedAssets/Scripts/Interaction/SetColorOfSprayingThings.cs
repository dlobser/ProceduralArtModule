using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable_ChooseColor))]
public class SetColorOfSprayingThings : MonoBehaviour
{

    public ParticleSystem pSystem;
    public Material material;
    Interactable_ChooseColor chooseColor;
    Color prevColor;

    void Start()
    {
        chooseColor = GetComponent<Interactable_ChooseColor>();
        SetColor();
    }

    void Update()
    {

        if(!prevColor.Equals(chooseColor.color)){
            SetColor();
        }
        prevColor = chooseColor.color;
    }

    void SetColor(){
        ParticleSystem.MainModule module = pSystem.main;
        module.startColor = chooseColor.color;
        material.color = chooseColor.color;
    }
}
