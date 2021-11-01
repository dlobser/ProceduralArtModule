// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(Atoms))]
[CanEditMultipleObjects]
public class AtomsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Atoms atoms = (Atoms) target;
        if(GUILayout.Button("Rebuild")){
            atoms.Rebuild();
        }
        UnityEditor.EditorUtility.SetDirty(target);
    }
}
#endif

[ExecuteAlways]
public class Atoms : MonoBehaviour
{
    public GameObject atom;
    public int amount;
    List<GameObject> atoms;
    Vector3 counter;
    public Vector3 speed;
    public Vector3 scale;
    public Vector3 spread;
    public float ballScale;
    public bool rebuild;

    public Vector3 rspeed;
    public Vector3 rscale;
    public Vector3 rspread;

    public Vector3 ispeed;
    public Vector3 iscale;
    public Vector3 ispread;

    public float line;
    public float circle;

    public bool randomize;

    public LineRenderer lineRenderer;
    public float lineWidth;
    public int lineDetail = 10;
    
    void Start()
    {
       Rebuild();

    }

    void Randomize(){
        ispeed = new Vector3(
            Random.Range(speed.x-rspeed.x,speed.x+rspeed.x),
            Random.Range(speed.y-rspeed.y,speed.y+rspeed.y),
            Random.Range(speed.z-rspeed.z,speed.z+rspeed.z)
        );
        iscale = new Vector3(
            Random.Range(scale.x-rscale.x,scale.x+rscale.x),
            Random.Range(scale.y-rscale.y,scale.y+rscale.y),
            Random.Range(scale.z-rscale.z,scale.z+rscale.z)
        );
        ispread = new Vector3(
            Random.Range(spread.x-rspread.x,spread.x+rspread.x),
            Random.Range(spread.y-rspread.y,spread.y+rspread.y),
            Random.Range(spread.z-rspread.z,spread.z+rspread.z)
        );
    }

    public void Rebuild(){
        if(this.transform.childCount>0){
            for (int i =  this.transform.childCount-1; i >=0; i--)
            {
                DestroyImmediate(this.transform.GetChild(i).gameObject);
            }
        }

        atoms = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            atoms.Add(Instantiate(atom,this.transform));
        }
        rebuild = false;
        Randomize();
    }

    void Update()
    {
        if(randomize){
            randomize=false;
            Randomize();
        }
        counter.x+=Time.deltaTime*ispeed.x;
        counter.y+=Time.deltaTime*ispeed.y;
        counter.z+=Time.deltaTime*ispeed.z;

        Vector3[] linePoints = new Vector3[amount*lineDetail];

        for (int i = 0; i < Mathf.Min(amount,atoms.Count); i++)
        {
            float off = ((float)i/(float)amount) * Mathf.PI*2;

            Vector3 lissa = new Vector3(
                Mathf.Sin(counter.x+off*ispread.x)*iscale.x,
                Mathf.Cos(counter.y+off*ispread.y)*iscale.y,
                Mathf.Sin(counter.z+off*ispread.z)*iscale.z);

            Vector3 row = new Vector3(
                Mathf.Sin(counter.x)*(off-Mathf.PI + (Mathf.PI/amount))*iscale.x,
                Mathf.Cos(counter.y)*(off-Mathf.PI+ (Mathf.PI/amount))*iscale.x,
                0);

            Vector3 c = new Vector3(
                Mathf.Sin(Time.time*ispeed.x+off*ispread.x)*iscale.x,
                Mathf.Cos(Time.time*ispeed.x+off*ispread.x)*iscale.x,
                0);

            atoms[i].transform.localPosition = Vector3.Lerp(Vector3.Lerp(lissa,row,line),c,circle);

            atoms[i].transform.LookAt(Camera.main.transform.position);
            atoms[i].transform.localScale = new Vector3(ballScale,ballScale,ballScale);
        }

        if(lineRenderer!=null){
            for (int i = 0; i < amount*lineDetail; i++)
            {
                float off = ((float)i/((float)amount*lineDetail)) * Mathf.PI*2;

                Vector3 lissa = new Vector3(
                    Mathf.Sin(counter.x+off*ispread.x)*iscale.x,
                    Mathf.Cos(counter.y+off*ispread.y)*iscale.y,
                    Mathf.Sin(counter.z+off*ispread.z)*iscale.z);

                Vector3 row = new Vector3(
                    Mathf.Sin(counter.x)*(off-Mathf.PI)*iscale.x,
                    Mathf.Cos(counter.y)*(off-Mathf.PI)*iscale.x,
                    0);

                Vector3 c = new Vector3(
                    Mathf.Sin(Time.time*ispeed.x+off*ispread.x)*iscale.x,
                    Mathf.Cos(Time.time*ispeed.x+off*ispread.x)*iscale.x,
                    0);

                linePoints[i] = Vector3.Lerp(Vector3.Lerp(lissa,row,line),c,circle);
            }

       
            lineRenderer.positionCount = amount*lineDetail;
            lineRenderer.SetPositions(linePoints);
            lineRenderer.widthMultiplier = lineWidth;
        }
    }
}
