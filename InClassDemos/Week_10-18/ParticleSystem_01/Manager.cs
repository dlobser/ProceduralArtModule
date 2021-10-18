using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particle_System
{
    public class Manager : MonoBehaviour
    {
        //an array of particles
        //it needs a public Particle
        //a loop to instantiate and position particles
        //on creation is calls 'rebuild' from the particle script;
        public Particle[] particle;
        Particle[] particles;
        public int amount;

        public bool rebuild;

        GameObject root;

        public Vector2 scaleMinMax;
        public Vector2 amountMinMax;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (rebuild)
            {
                Rebuild();
                rebuild = false;
            }
        }

        public void Rebuild()
        {
            if (root != null)
            {
                Destroy(root);
            }

            root = new GameObject("Root");

            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    GameObject g = Instantiate(particle[Random.Range(0,particle.Length)].gameObject);

                    Particle p = g.GetComponent<Particle>();
                    p.amount = Random.Range((int)amountMinMax.x, (int)amountMinMax.y);
                    p.scale = Random.Range(scaleMinMax.x,scaleMinMax.y);
                    p.Rebuild();

                    g.transform.localPosition = new Vector3(i, j, 0);
                    g.transform.parent = root.transform;
                }
            }
        }
    }
}