using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Fruit
{
    void Start()
    {
        color = new Color(1, .5f, 0);
    }

    public override void Eat()
    {
        base.Eat();

        print("I like to eat oranges");
    }


}
