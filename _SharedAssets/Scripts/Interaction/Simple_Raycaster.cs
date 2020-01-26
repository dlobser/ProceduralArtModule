
using UnityEngine;

public class Simple_Raycaster : MonoBehaviour
{
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit;
        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit)
        {
            if (hitInfo.transform.gameObject.GetComponent<Simple_Interactable>() != null)
            {
                hitInfo.transform.gameObject.GetComponent<Simple_Interactable>().OnRaycastHit();
            }
        }
    }
}
