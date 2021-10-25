using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particle_System
{
    public class Particle : MonoBehaviour
    {
        public float scale;
        public int amount;
        public virtual void Rebuild() { }
    }

}