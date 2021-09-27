using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
    public Transform ObjectA;
    public Vector3 maxRange;
    public Vector3 minRange;

    public bool randomize;
    public bool showGUI;

    void OnGUI()
    {
        if (showGUI)
        {
            if (GUILayout.Button("Randomize"))
                Randomize();
            if (GUILayout.Button("Save Image"))
                SaveImage();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Randomize();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveImage();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            showGUI = !showGUI;
        }
        if (randomize)
        {
            Randomize();
            randomize = false;
        }
    }

    public void Randomize()
    {
        ObjectA.transform.localPosition = new Vector3(
                Random.Range(minRange.x, maxRange.x),
                Random.Range(minRange.y, maxRange.y),
                Random.Range(minRange.z, maxRange.z));
    }

    public void SaveImage()
    {
        ScreenCapture.CaptureScreenshot("Assets/capture_" + System.DateTime.Now.ToString("dd_MM_yyyy_hh-mm-ss") + ".jpg");
    }
}
