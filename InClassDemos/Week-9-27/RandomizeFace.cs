using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeFace : MonoBehaviour
{

    public Color[] colors;

    public Transform mouth;
    public Transform eye;
    public Transform eyebrow_L;
    public Transform eyebrow_R;
    public Transform nose;

    public bool randomize;

    public float minMouthWidth = .2f;
    public float maxMouthWidth = .5f;

    public float minMouthHeight = .1f;
    public float maxMouthHeight = .2f;

    [Tooltip("X:min, Y:max")]
    public Vector2 eyebrowRotation;

    [Tooltip("X:min, Y:max")]
    public Vector2 mouthRotation;

    void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    GameObject g = Instantiate(eye.gameObject);
        //    g.transform.localPosition = new Vector3(0, i, 0);
        //    g.transform.localEulerAngles = MakeRandomVector(Vector3.zero, Vector3.one * 90);
        //    g.transform.localScale = MakeRandomVector(Vector3.one, Vector3.one * 5);

        //}

        //InvokeRepeating("Randomize", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            randomize = true;
        }
        if (randomize)
        {
            Randomize();
            RandomizeColor();
            randomize = false;
        }
    }

    void Randomize()
    {

        //Mouth rotation
        Vector3 rotationForMouth = MakeRandomVector(
            new Vector3(0, 0, mouthRotation.x), 
            new Vector3(0, 0, mouthRotation.y));
        mouth.localEulerAngles = rotationForMouth;

        //Mouth scale
        mouth.localScale = MakeRandomVector(
            new Vector3(minMouthWidth, minMouthHeight, .2f), 
            new Vector3(maxMouthWidth, maxMouthHeight, .2f));

        //Eyebrow Rotation
        float eyebrowEulerAngles = Random.Range(eyebrowRotation.x, eyebrowRotation.y);

    }

    void RandomizeColor()
    {
        MeshRenderer meshRenderer = mouth.GetComponent<MeshRenderer>();
        meshRenderer.material.color = colors[Random.Range(0, colors.Length)];

        meshRenderer = nose.GetComponent<MeshRenderer>();
        meshRenderer.material.color = colors[Random.Range(0, colors.Length)];

        eyebrow_L.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)]; ;
    }

    Vector3 MakeRandomVector(Vector3 min, Vector3 max)
    {
        return new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z));
    }

  
}
