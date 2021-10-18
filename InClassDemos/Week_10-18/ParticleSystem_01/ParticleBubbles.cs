using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particle_System
{
    public class ParticleBubbles : Particle
    {
        public GameObject part;

        public override void Rebuild()
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject bubble = Instantiate(part);
                bubble.transform.localEulerAngles = Random.insideUnitSphere * 360;
                bubble.transform.localScale = new Vector3(scale,scale, scale);
                bubble.transform.localPosition = Random.insideUnitSphere;
                bubble.transform.parent = this.transform;
                this.transform.localScale = Vector3.one * .3f;
            }

        }
    }
}