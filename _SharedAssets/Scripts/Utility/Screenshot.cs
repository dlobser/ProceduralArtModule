using UnityEngine;
using System;

public class Screenshot : MonoBehaviour
{
    public string screenshotName = "screenshot";
    public int superSize = 1;

	private void Update()
	{
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.S)){
            ScreenCapture.CaptureScreenshot(screenshotName + DateTime.Now.ToString("_MM_dd_HH_mm_ss"), superSize);
        }
	}
}
