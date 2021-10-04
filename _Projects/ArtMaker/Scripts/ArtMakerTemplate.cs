using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class ArtMakerTemplate : ArtMaker
    {

        public GameObject root { get; set; }

        void LateUpdate()
        {
            if (Input.GetKey(KeyCode.R))
                rebuild = true;
            if (rebuild)
            {
                Rebuild();
                rebuild = false;
            }
        }

        public override void Rebuild()
        {
            if (root != null)
            {
                Destroy(root);
            }

            root = new GameObject();
            root.name = "ArtMaker_Root";
            MakeArt();
        }

        public void AddToRoot(Transform t)
        {
            t.transform.parent = root.transform;
        }

        public virtual void MakeArt()
        {
            /*
             * Make your art in this function
             * Make every new object the child of root.transform
             * "yourGameObject.transform.SetParent(root.transform);"
             * or
             * "yourGameObject.transform.parent = root.transform;
             */
        }
    }
}
