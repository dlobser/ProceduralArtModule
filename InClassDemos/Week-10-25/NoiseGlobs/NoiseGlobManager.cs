using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGlobManager : MonoBehaviour
{
    public NoiseGlob glob;
    public int amount;
    GameObject root;
    public float minScale;
    public float maxScale;

    public float noiseFrequency;
    
    // Start is called before the first frame update

    public void Start(){
        Rebuild();
    }
    
    void Update(){
        Rebuild();
    }

    public void Rebuild()
    {
        if(root!=null){
            Destroy(root);
        }
        root = new GameObject();
        for (int i = 0; i < amount; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                NoiseGlob thisGlob = Instantiate(glob,root.transform);
                thisGlob.transform.localPosition = new Vector3(i,j,0);
                float noiseMult = Mathf.Max(0,Mathf.PerlinNoise(i*noiseFrequency*.2f + Time.time*-.2f,j*noiseFrequency*.2f)*maxScale-5);
                float noiseScale = Mathf.PerlinNoise(i*noiseFrequency + Time.time,j*noiseFrequency)*maxScale*noiseMult;
                thisGlob.scale = noiseScale;// Random.Range(minScale,maxScale);
                thisGlob.Rebuild();
            }
        }
    }
}
