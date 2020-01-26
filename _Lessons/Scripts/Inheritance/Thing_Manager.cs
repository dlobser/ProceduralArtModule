using UnityEngine;

public class Thing_Manager : MonoBehaviour
{
    public Thing_BaseClass[] things;
    public int amount;
    public float spread;

    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(
                //choose a random object from our array of objects defined in the editor
                things[Random.Range(0, things.Length)].gameObject, 
                //place it randomly
                Random.insideUnitSphere * spread,
                //set the rotation to zero
                Quaternion.identity,
                //set the parent to be the object that this script is attached to
                this.transform);
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).GetComponent<Thing_BaseClass>().Trigger();
            }
        }
    }
}
