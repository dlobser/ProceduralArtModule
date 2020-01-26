using UnityEngine;

public class Simple_Interactable : MonoBehaviour
{
    public virtual void OnRaycastHit(){
        print(this.gameObject.name + " was hit");
    }
}
