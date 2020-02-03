using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Maze{
	public class Cell : MonoBehaviour {

		public Cell[] neighbors { get; set; }
		public int[] neighborID { get; set; }
		public bool[] activeCells;
		public GameObject[] cellWalls{ get; set; }
		public Vector3 size;
		public GameObject[] walls;
		public GameObject[] floors;
		public GameObject[] ceilings;
		public int id;
		public float randomSeed { get; set; }

		public bool displayText = false;
		public TextMesh txt;

		public void Init () {
			txt = GetComponent<TextMesh> ();
			if (!displayText)
				GetComponent<MeshRenderer> ().enabled = false;
			neighbors = new Cell[6];
			neighborID = new int[6];
			activeCells = new bool[6];
			for (int i = 0; i < activeCells.Length; i++) {
				activeCells [i] = true;
			}
				
			cellWalls = new GameObject[6];
			cellWalls[0] = makeEdge (walls, 0, 0, .5f, 0, 0, 0);
			cellWalls[1] = makeEdge (walls, .5f, 0, 0, 0, 90f, 0);
			cellWalls[2] = makeEdge (walls, 0, 0, -.5f, 0, 180f, 0);
			cellWalls[3] = makeEdge (walls, -.5f, 0, 0, 0, -90f, 0);
			cellWalls[4] = makeEdge (ceilings, 0, .5f,0, -90, 0, 0);
			cellWalls[5] = makeEdge (floors, 0, -.5f,0, 90, 0, 0);
		}

		GameObject makeEdge(GameObject[] element, float posX,float posY, float posZ, float rotX, float rotY, float rotZ){
			GameObject Edge = Instantiate (
				element [(int)(Random.value * element.Length)], 
				new Vector3 (posX,posY,posZ), 
				Quaternion.Euler (rotX,rotY,rotZ), 
				this.transform) as GameObject;
			return Edge;
		}

		float NoiseValue(float val){
			float outVal = Mathf.PerlinNoise (randomSeed * val, randomSeed * val);
			return outVal;
		}

		public int GetWallCount(){
			int active = 0;
			for (int i = 0; i < 6; i++) {
				if (cellWalls [i].activeInHierarchy) {
					active++;
				}
			}
			return active;
		}

		void SetActiveWalls(){
			for (int i = 0; i < 6; i++) {
				if (neighborID [i] == -1)
					activeCells [i] = false;
			}
		}

		public int FindRemovableWall(){
			int empty = -1;
			List<int> empties = new List<int> ();
			for (int i = 0; i < 4; i++) {
				if (neighborID [i] != -1 && cellWalls [i].activeInHierarchy) {
					empties.Add (i);
				
				}
			}
			string p = "";
			for (int i = 0; i < empties.Count; i++) {
				p += empties [i] + ",";
			}
			if (empties.Count > 0) {
				float ns = (NoiseValue((float)id*.1f) * empties.Count);
				empty = empties[(int)ns];
			}
			return empty;
		}

		public void HideWall(int which, bool recurse){

			if (which != -1) {
				if (neighborID [which] != -1) {
				
					if (cellWalls [which].activeInHierarchy)
						cellWalls [which].SetActive (false);

					activeCells [which] = true;

					int hideOtherWall = -1;
					switch (which) {
					case 0:
						hideOtherWall = 2;
						break;
					case 1:
						hideOtherWall = 3;
						break;
					case 2: 
						hideOtherWall = 0;
						break;
					case 3:
						hideOtherWall = 1;
						break;
					case 4:
						hideOtherWall = 5;
						break;
					case 5:
						hideOtherWall = 4;
						break;
					default:
						Debug.LogWarning ("missing wall");
						break;
					}
//					if (hideOtherWall == 2)
//						Debug.Log (neighbors [which]);
					if (recurse)
						neighbors [which].HideWall (hideOtherWall, false);
			
				} else
					activeCells [which] = false;
				SetActiveWalls ();
			}
		}

		public void RemoveDuplicateWalls(){
			if(neighbors [0]!=null)
				if (cellWalls [0].activeInHierarchy && neighbors [0].cellWalls [2].activeInHierarchy)
					cellWalls [0].SetActive (false);
			if(neighbors [1]!=null)
				if (cellWalls [1].activeInHierarchy && neighbors [1].cellWalls [3].activeInHierarchy)
					cellWalls [1].SetActive (false);
			if(neighbors [2]!=null)
				if (cellWalls [2].activeInHierarchy && neighbors [2].cellWalls [0].activeInHierarchy)
					cellWalls [2].SetActive (false);
			if(neighbors [3]!=null)
				if (cellWalls [3].activeInHierarchy && neighbors [3].cellWalls [1].activeInHierarchy)
					cellWalls [3].SetActive (false);
			
			
			
		}

	}
}