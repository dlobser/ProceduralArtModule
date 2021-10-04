using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durian : Fruit
{
    void Start()
    {
        color = new Color(.6f, .5f, .2f);
    }

    public override void Eat()
    {
        base.Eat();

        print("I have mixed feelings about Durian");
    }
}
