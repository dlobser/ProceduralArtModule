using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    public GameObject thing;

    //[] Square brackets denotes an array
    //An array is a collection of things, you can make an array of any variable

    GameObject[] things;
    public int amount;

    void Start()
    {
        //An array must be created with a set size, you can't change the size of an array

        things = new GameObject[amount];

        //This is a 'for' loop
        //We declare the integer value 'i' - as long as i is less than 'amount'
        //1 will be added to i - 'i++' is the same as 'i = i+1'
        //and whatever is inside the {} curly braces will be executed
        //for loops are very useful!

        for (int i = 0; i < amount; i++)
        {
            //things[0] is the first item in the things array
            //things[1] is the second, and so on until the end
            //The command below creates a new thing and assigns it to a slot in the array
            //We make a new Vector for the position and use i to offset the x value
            things[i] = Instantiate(thing);
        }

    }

	private void Update()
	{
        
        for (int i = 0; i < amount; i++)
        {
            things[i].transform.position = 
                new Vector3(i, Mathf.Sin(Time.time + i), 0);
        }

	}

}
