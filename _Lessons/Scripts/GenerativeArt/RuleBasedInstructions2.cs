using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleBasedInstructions2 : MonoBehaviour
{
    /*
     * Draw a line from one side and connect it to the other side
     * Then fill up on side of the paper with parallel lines
     * and on the other side, draw a shape
     * 
     */

    public bool rebuild;

    public string[] shapes;
    public string[] lineTypes;

    int num = 0;
    string output = "";

    void Start()
    {
        shapes = new string[] { "circle","square","triangle","x" };
        lineTypes = new string[] { "straight", "curved", "wobbly", "jagged", "dotted" };
    }

    void Update()
    {
        if(rebuild){

            output += "\nStart in the lower left and move your pencil ";

            int amount = Random.Range(0, 100);

            output += amount + "% of the way to the right side and draw a dot.\n";

            output += "Start in the upper left and move your pencil ";

            amount = Random.Range(0, 100);

            output += amount + "% of the way to the right side and draw a dot.\n";

            string lineType = lineTypes[Random.Range(0, lineTypes.Length)];

            output += "Connect these dots together with a " + lineType + " line.\n";

            string whichSide = (Random.value > .5f) ? "left" : "right";
                
            output += "Draw a series of parrallel lines to the " + whichSide + " of the line.\n";

            string shape = shapes[Random.Range(0, shapes.Length)];

            whichSide = (Random.value > .5f) ? "upper" : "lower";

            output += "Draw a " + shape + " on the " + whichSide + " half of the opposite side of the paper.\n";

            num++;

            if (num > 9)
            {
                print(output);
                rebuild = false;
                output = "";
            }
        }
    }
}
