using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compare : MonoBehaviour
{
    public int A;
    public int B;

    /*
     * < less than
     * > greater than
     * <= less than or equal to
     * >= greater than or equal to
     * != does not equal
     * == equals
     * && and
     * || or
     */

    void Start()
    {


    }

	void Update()
	{
        
        if (A > B){
            print("A is greater than B");
        }
        if (A == B){
            print("A equals B");
        }
        if(A <= B){
            print("A is less than or equal to B");
        }
        if(A < B || A > B){
            print("A is less than or greater than B");
        }
        if(A != B){
            print("A does not equal B");
        }
        if(A == B && B > 10 && A > 10){
            print("A equals B and B is greater than 10");
        }

        
        //Visual Studio will complain about comparing 
        //float values with == 
        //In some cases you will need to use the .Equals() function

        //float a = 1.5f;
        //float b = 1.5f;
        //if (a == b)
        //    print("float a = float b");
        //if (a.Equals(b))
            //print("float a = float b");
        
        
        /* 
         * ifs and elses
         * 
         * we don't really need to check if A==B because
         * if it's not less than or greater than it will be equal to
         * if the first if is true the following else statements will
         * not be checked, the final else becomes the default state
         */
        //if (A < B){
        //    print("A is less than B");
        //}
        //else if (A > B){
        //    print("A is greater than B");
        //}
        //else{
        //    print("A equals B");
        //}


	}

}
