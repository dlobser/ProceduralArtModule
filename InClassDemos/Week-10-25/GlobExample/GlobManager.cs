using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobManager : MonoBehaviour
{
    public Glob glob;
    public int amount;
    // Start is called before the first frame update
    public void Rebuild()
    {
         for (int i = 0; i < amount; i++)
        {
            Glob thisGlob = Instantiate(glob.gameObject, this.transform).GetComponent<Glob>();
            thisGlob.transform.localPosition = Random.insideUnitSphere*20;
            thisGlob.Rebuild();
        }
    }

  
}
