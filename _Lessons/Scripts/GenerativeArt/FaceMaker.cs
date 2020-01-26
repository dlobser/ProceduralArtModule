using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMaker : MonoBehaviour
{
    public string[] eyes;
    public string[] noses;
    public string[] mouths;

    public TextMesh LEye;
    public TextMesh REye;
    public TextMesh Nose;
    public TextMesh Mouth;

    public bool rebuild = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(rebuild){
            MakeFace();
            rebuild = false;
        }
    }

    void MakeFace(){
        
        string eye = eyes[Random.Range(0, eyes.Length)];
        string nose = noses[Random.Range(0, noses.Length)];
        string mouth = mouths[Random.Range(0, mouths.Length)];

        LEye.text = eye;
        REye.text = eye;
        Nose.text = nose;
        Mouth.text = mouth;

    }
}
