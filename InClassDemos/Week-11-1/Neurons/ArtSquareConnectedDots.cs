using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Art;

namespace ArtExample
{
    public class ArtSquareConnectedDots : ArtMakerTemplate
    {

        public int amount = 10;
        GameObject[] lines;
        Vector3[] points;
        public int detail;
        public float translateAmount;
        public float spread;
        public float noiseDetail;
        public Material material;
        public float lineWidth;
        public Vector2[] animCurve;
        public float steer = 180;
        public float minDist = 5;
        public Gradient gradient;
        public float minWidth = .1f;
        public AnimationCurve curve;

        List<LineRenderer> lineRenderers;
        public int seed;

        void Update(){
           
            AnimationCurve c = new AnimationCurve(
                new Keyframe(animCurve[0].x,animCurve[0].y * lineWidth),
                new Keyframe(animCurve[1].x,animCurve[1].y * lineWidth),
                new Keyframe(animCurve[2].x,animCurve[2].y * lineWidth),
                new Keyframe(animCurve[3].x,animCurve[3].y * lineWidth)
                );
            foreach(LineRenderer l in lineRenderers){
                l.widthCurve = c;
            }
            
        }

        public override void MakeArt()
        {
            Random.InitState(seed);
            int amt = amount;
            points = new Vector3[amt];
            lineRenderers = new List<LineRenderer>();
            
            for (int i = 0; i < amt; i++)
            {
                points[i] = Random.insideUnitSphere * spread;
            }

            for (int i = 0; i < amt; i++)
            {
                for (int j = 0; j < amt; j++)
                {
                    if(i!=j && Vector3.Distance(points[i],points[j])<minDist){
                        GameObject l = new GameObject();
                        LineRenderer r = l.AddComponent<LineRenderer>();
                        lineRenderers.Add(r);
                        r.widthMultiplier = lineWidth;
                        r.widthCurve = new AnimationCurve(new Keyframe(0,1),new Keyframe(.5f,minWidth),new Keyframe(1,1));//))
                        r.colorGradient = gradient;
                        r.material = material;
                        l.transform.parent = root.transform;
                        r.positionCount = detail+1;
                        Vector3[] ps = new Vector3[detail+1];

                        GameObject g = new GameObject();
                        g.transform.position = points[i];
                        g.transform.LookAt(points[j]);
                        float d = Vector3.Distance(points[i],points[j]);

                        for (int k = 0; k < detail; k++)
                        {
                            ps[k] = g.transform.position;

                            g.transform.Translate(g.transform.forward*translateAmount);
                            g.transform.Rotate((Mathf.PerlinNoise(g.transform.position.x*noiseDetail,0)-.5f)*steer,(Mathf.PerlinNoise(g.transform.position.y*noiseDetail,0)-.5f)*steer,0);
                        }

                         for (int k = 0; k < detail; k++)
                        {
                            float p = (float)k/(float)detail;          
                            ps[k] = Vector3.Lerp(ps[k],points[j],p);
                        }

                        ps[ps.Length-1] = points[j];

                        r.SetPositions(ps);
                        Destroy(g);

                    }
                }
            }
        }
    }
}