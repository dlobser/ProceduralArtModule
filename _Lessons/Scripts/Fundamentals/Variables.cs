using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int integerValue;
    public float floatValue;
    public float secondFloatValue;
    public bool isItTrue;

    public string stringValue;
    public Vector3 vectorValue;

    //primitive variables in c#: int, short, long, byte, float, double, char, and boolean.
    //int, float, bool and string are the most common 
    //but you may see long, short, byte, double and char in other's scripts
    //long, short and byte are types of integers
    //Double is similar to float but with more precision (15 or 16 decimal points vs 6 or 7)
    //char variables hold a sixteen-bit number representing a letter, digit, symbol or control character. 

    //Vector3 is not a primitive variable but is a 'struct' which is similar to a 'class'

    //This is the start function, everything inside it gets called on start
    void Start()
    {
        
    }

    //This function is called automatically every frame
    //It says "void" because it doesn't return anything
    void Update()
    {
        print("Integers are whole numbers, such as: " + integerValue + "\n");
        print("Floating point numbers contain decimal points, such as: " + floatValue + "\n");
        print("Booleans are true or false: " + isItTrue + "\n");
        print("Strings are letters, words and sentences: " + stringValue + "\n");
        print("Vectors are special objects which contain 2, 3, or 4 floats: " + vectorValue + "\n");
        float addedUp = Add(floatValue, secondFloatValue);
        print("Functions can do things like add numbers together: " + addedUp + "\n");

    }

    //instead of 'void' we use 'float' because it returns a float
    float Add(float A, float B){
        return A + B;
    }
}
