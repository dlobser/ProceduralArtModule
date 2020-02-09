using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collections : MonoBehaviour
{
    int[] intArray;
    List<int> intList;

    public int size;

    public int index;

    void Start()
    {
        //initialize

        intArray = new int[size];
        intList = new List<int>();

        //fill with values

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = Random.Range(0, intArray.Length);
        }

        for (int i = 0; i < size; i++)
        {
            intList.Add((int)(Random.value * size));
        }

        //access the values

        string arrayString = "";
        for (int i = 0; i < intArray.Length; i++)
        {
            arrayString += intArray[i] + ", ";
        }

        /*
         * using foreach and while loops
         * to do the same thing as the for loop
         */

        //foreach (int integer in intArray)
        //    arrayString += integer + ", ";

        //int j = 0;
        //while(j < intArray.Length){
        //    arrayString += intArray[j] + ", ";
        //    j++;
        //}


        print(arrayString);

        string listString = "";
        for (int i = 0; i < intList.Count; i++)
        {
            listString += intList[i] + ", ";
        }

        print(listString);
    }

    void Update()
    {
        print("intArray: " + intArray[index]);
        print("intList: " + intList[index]);

    }
}
