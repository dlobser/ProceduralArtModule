using UnityEngine;

public class Loops : MonoBehaviour
{
    void Start()
    {
        //WhileLoop();
        ForLoop();
        //ForLoop2D();
        //ForEachLoop();
    }

    void WhileLoop()
    {
        int i = 0;
        while (i < 10)
        {
            i = i+1;
            print("While: " + i);

        }
    }

    void ForLoop(){
        for (int i = 0; i < 10; i++)
        {
            print("For Loop: " + i);
        }

    }

    void ForLoop2D()
    {
        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                print("2D For Loop: i " + i + " , j " + j + " , k " + k);
                k++;
            }
        }
    }

    void ForEachLoop(){
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        foreach(int i in numbers){
            print("foreach: " + i);
        }
    }
}
