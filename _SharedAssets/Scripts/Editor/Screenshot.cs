using UnityEditor;
using UnityEngine;
public class MenuTest : MonoBehaviour
{
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("CU/SaveScreenshot")]
    static void Snapshot()
    {
        ScreenCapture.CaptureScreenshot("screenshot_" + System.DateTime.Now.ToString("dd_MM_yyyy_hh-mm-ss") + ".jpg");

    }

}