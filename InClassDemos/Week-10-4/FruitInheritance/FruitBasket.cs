using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBasket : MonoBehaviour
{
    public Fruit[] fruits;

    void Start()
    {
        for (int i = 0; i < fruits.Length; i++)
        {
            fruits[i].Eat();
        }
    }

    void Update()
    {
        
    }
}
