using UnityEngine;

public class Recursion : MonoBehaviour
{
    public Transform thing;
    Transform root;
    public int amount;

    //these variables control the animation
    public float speed;
    public float amplitude;
    public float frequency;

    void Start()
    {
        //Begin recursing by creating a new object and setting 0 as the first index
        root = Instantiate(thing);
        Branch(root, 0);
    }


    private void Update()
    {
        AnimateBranch(root, 0);
    }

    //A function that calls itself, it gets a transform and an index
    //We use the index to prevent the function from recursing forever
    void Branch(Transform p, int index){

        //Make a new object
        Transform t = Instantiate(thing);

        //parent it to the object which was passed in to the function
        t.parent = p;

        //this will move our new object to be just above the object we passed in
        t.localPosition = Vector3.up;

        //increment the index so we don't go on forever
        int newIndex = index + 1;

        //we call the function from inside itself == recursion!
        if (newIndex < amount)
            Branch(t, newIndex);

        else
            print("finished");
    }

    void AnimateBranch(Transform t, int index){
        t.localEulerAngles = Vector3.forward * Mathf.Sin(Time.time * speed + index * frequency) * amplitude;
        if (t.childCount > 0)
            AnimateBranch(t.GetChild(0), ++index);
    }


}
