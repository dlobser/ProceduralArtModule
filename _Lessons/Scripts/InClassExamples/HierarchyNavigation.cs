using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Art
{
    public class HierarchyNavigation : ArtMakerTemplate
    {
        public GameObject bodyGeo;
        public float armSwing = 20;

        GameObject LArm, RArm, LLeg, RLeg;

        bool initialized = false;

		public override void MakeArt()
		{
            GameObject body = DoubleJoint();
            body.transform.parent = root.transform;
            body.name = "Body";

            float randoArmSwing = Random.value;

            LArm = DoubleJoint();
            LArm.gameObject.name = "LArm";
            LArm.transform.parent = body.transform;
            LArm.transform.localEulerAngles = new Vector3(0, 0, randoArmSwing * -armSwing);
            LArm.transform.GetChild(1).localEulerAngles = LArm.transform.localEulerAngles;

            RArm = DoubleJoint();
            RArm.gameObject.name = "RArm";
            RArm.transform.parent = body.transform;
            RArm.transform.localEulerAngles = new Vector3(0, 0, randoArmSwing * armSwing);
            RArm.transform.GetChild(1).localEulerAngles = RArm.transform.localEulerAngles;

            float randoLegSwing = Random.value;

            Transform jointIwantToParentTo = body.transform.GetChild(1);

            LLeg = DoubleJoint();
            LLeg.gameObject.name = "RLeg";
            LLeg.transform.parent = jointIwantToParentTo;
            LLeg.transform.localPosition = new Vector3(0, -1, 0);
            LLeg.transform.localEulerAngles = new Vector3(0, 0, randoLegSwing * -armSwing);
            LLeg.transform.GetChild(1).localEulerAngles = LLeg.transform.localEulerAngles;

            RLeg = DoubleJoint();
            RLeg.gameObject.name = "RLeg";
            RLeg.transform.parent = jointIwantToParentTo;
            RLeg.transform.localPosition = new Vector3(0, -1, 0);
            RLeg.transform.localEulerAngles = new Vector3(0, 0, randoLegSwing * armSwing);
            RLeg.transform.GetChild(1).localEulerAngles = RLeg.transform.localEulerAngles;

            initialized = true;
		}

		GameObject DoubleJoint(){
            GameObject iDunno = MakeJoint();
            GameObject lowerIDunno = MakeJoint();
            lowerIDunno.name = "lowerJoint";
            lowerIDunno.transform.parent = iDunno.transform;
            lowerIDunno.transform.localPosition = new Vector3(0, -1, 0);
            return iDunno;
        }

        GameObject MakeJoint(){
            GameObject Root = new GameObject("Root");
            Root.name = "Root";
            GameObject geo = Instantiate(bodyGeo);
            geo.transform.parent = Root.transform;
            geo.transform.localPosition = new Vector3(0, -.5f, 0);
            geo.transform.localScale = new Vector3(.2f, 1, .2f);
            return Root;
        }

        float Add(float A, float B){
            return A + B;
        }
	}
}