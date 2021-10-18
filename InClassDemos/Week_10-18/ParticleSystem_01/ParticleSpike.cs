using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particle_System
{
    public class ParticleSpike : Particle
    {
        public GameObject part;

        public override void Rebuild()
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject spike = Instantiate(part);
                spike.transform.localEulerAngles = Random.insideUnitSphere * 360;
                spike.transform.localScale = new Vector3(1, 1, scale);
                spike.transform.parent = this.transform;
            }

        }
    }
}