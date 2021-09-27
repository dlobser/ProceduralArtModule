using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize_TRS : MonoBehaviour
{
    public Vector3 minPosition;
    public Vector3 maxPosition;

    public Vector3 minEulerAngles;
    public Vector3 maxEulerAngles;

    public Vector3 minScale;
    public Vector3 maxScale;

    public Transform target;

    public bool setRandomPosition;
    public bool setRandomEulerAngles;
    public bool setRandomScale;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            setRandomPosition = true;
            setRandomEulerAngles = true;
            setRandomScale = true;
        }
        if (setRandomPosition)
        {
            SetRandomPosition();
            setRandomPosition = false;
        }
        if (setRandomEulerAngles)
        {
            SetRandomEulerAngles();
            setRandomEulerAngles = false;
        }
        if (setRandomScale)
        {
            SetRandomScale();
            setRandomScale = false;
        }
    }

    void SetRandomPosition()
    {
        target.transform.localPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z));
    }

    void SetRandomEulerAngles()
    {
        target.transform.localEulerAngles = new Vector3(
            Random.Range(minEulerAngles.x, maxEulerAngles.x),
            Random.Range(minEulerAngles.y, maxEulerAngles.y),
            Random.Range(minEulerAngles.z, maxEulerAngles.z));
    }
    void SetRandomScale()
    {
        target.transform.localScale = new Vector3(
            Random.Range(minScale.x, maxScale.x),
            Random.Range(minScale.y, maxScale.y),
            Random.Range(minScale.z, maxScale.z));
    }
}
