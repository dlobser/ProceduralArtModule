using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Maze{
	public class MazeBuilder : MonoBehaviour {

		public Cell cell;
		public GameObject cellContainer;
		List<Cell> cells;
		public Vector3 divisions;
		public Vector3 size;
		//public GameObject Point;
		//public GameObject PointParent;
		public float randomSeed;
		public bool randomizeRandomSeed;
		bool init;
        public bool rebuild;
        public bool useCoroutines;

        void Start () {
			RebuildMaze ();
		}

		void Update()
		{
            if (rebuild)
            {
                RebuildMaze();
                rebuild = false;
            }
		}

		public void RebuildMaze(){
			if (init) {
				for (int i = 0; i < cellContainer.transform.childCount; i++) {
					Destroy (cellContainer.transform.GetChild (i).gameObject);
				}
				//for (int i = 0; i < PointParent.transform.childCount; i++) {
				//	Destroy (PointParent.transform.GetChild (i).gameObject);
				//}
			}

			if(randomizeRandomSeed)
				randomSeed = Random.value * 100;
			
			SetupGrid ();
			MakeMaze ();
            GetComponent<PopulatePaintings>().Populate();
			init = true;

		}

		void SetupGrid(){

			int W = (int)divisions.x;
			int H = (int)divisions.y;
			int D = (int)divisions.z;

			cells = new List<Cell> ();
			for (int i = 0; i < W * H * D; i++) {
				cells.Add (cell);
			}

			
			for (int i = 0; i < W ; i++) {
				for (int j = 0; j < H ; j++) {
					for (int k = 0; k < D ; k++) {

						Cell cellInstance = Instantiate (cell) as Cell;
						cellInstance.Init ();

						Vector3 div = new Vector3( size.x / W , size.z / D , size.y / H );
						cellInstance.transform.position = new Vector3 (((float)i / W) * size.x, ((float)k /D) * size.z, ((float)j / H) * size.y) -
						new Vector3 (size.x * .5f, size.z * .5f, size.y * .5f) +
						div * .5f;

						//GameObject point = Instantiate (Point, cellInstance.transform.position, Quaternion.identity, PointParent.transform) as GameObject;
						//point.GetComponent<TransformUniversal> ().scaleOscillateOffset = new Vector3 (Random.value*10, Random.value*10, Random.value*10);
						//point.transform.localScale = new Vector3 ( div.x*.6f, div.y*.6f,  div.z*.6f);

						cellInstance.transform.localScale = new Vector3 ( div.x, div.y,  div.z);
						cellInstance.transform.parent = cellContainer.transform;

						int num = i + (j * W) + (k * W * H);

						//int max = W * H * D;

						cellInstance.neighborID [0] = (num + W) < W*H*D ? num+W : -1;
						cellInstance.neighborID [1] = (i + 1) < W ? num+1 : -1;
						cellInstance.neighborID [2] = (num - W) > -1 ? num-W : -1;
						cellInstance.neighborID [3] = (i - 1) > -1 ? num-1 : -1;

						cellInstance.txt.text = num+"\n,"+cellInstance.neighborID[0]+","+cellInstance.neighborID[1]+","+cellInstance.neighborID[2]+","+cellInstance.neighborID[3];
						cellInstance.gameObject.name = num+","+cellInstance.neighborID[0]+","+cellInstance.neighborID[1]+","+cellInstance.neighborID[2]+","+cellInstance.neighborID[3];
						cellInstance.randomSeed = randomSeed;
						cellInstance.id = num;
						cells[num] = (cellInstance);

					}
				}
			}
			for (int i = 0; i < cells.Count; i++) {
				if(cells [i].neighborID [0]>-1)
					cells [i].neighbors [0] = cells [cells [i].neighborID [0]];
				if(cells [i].neighborID [1]>-1)
					cells [i].neighbors [1] = cells [cells [i].neighborID [1]];
				if(cells [i].neighborID [2]>-1)
					cells [i].neighbors [2] = cells [cells [i].neighborID [2]];
				if(cells [i].neighborID [3]>-1)
					cells [i].neighbors [3] = cells [cells [i].neighborID [3]];
			}
		}

		void MakeMaze(){
            if (useCoroutines)
                StartCoroutine(hidewalls());
            else
            {
                HideWalls ();
                CleanUp ();
                RemoveEnclosedSpaces ();
                RemoveDuplicateWalls ();
            }
		}

		void RemoveDuplicateWalls(){
			for (int i = 0; i < cells.Count; i++) {
				cells [i].RemoveDuplicateWalls ();
			}
		}

		void RemoveEnclosedSpaces(){
			int[] c = new int[(int)(divisions.x * divisions.y * divisions.z)];
			for (int i = 0; i < c.Length; i++) {
				c [i] = 0;
			}
			int[] checker = CheckForEnclosedSpaces (0, c);
			int count = 0;
			for (int i = 0; i < checker.Length; i++) {
				if (checker [i] > 0)
					count++;
			}
			OpenClosedSpace (c);
		}

		int[] CheckForEnclosedSpaces(int index, int[] visited){
			Cell thisCell = cells [index];
			if (visited [index] != 1) {
				visited [index] = 1;
				for (int i = 0; i < 4; i++) {
					if (!thisCell.cellWalls [i].activeInHierarchy && visited [thisCell.neighbors [i].id] != 1) {
						CheckForEnclosedSpaces (thisCell.neighbors [i].id, visited);
					}
				}
			}
			return visited;
		}

		void OpenClosedSpace(int[] visited){
			List<int> unvisitedIndex = new List<int> ();
			for (int i = 0; i < visited.Length; i++) {
				if (visited [i] != 1)
					unvisitedIndex.Add (i);
			}
			bool found = false;
			for (int i = 0; i < unvisitedIndex.Count; i++) {
				if (found)
					break;
				else {
					Cell thisCell = cells [unvisitedIndex [i]];
					for (int j = 0; j < 4; j++) {
						if (thisCell.neighbors [j] != null) {
							if (thisCell.cellWalls [j].activeInHierarchy) {
								if (visited [thisCell.neighbors [j].id] == 1) {
									thisCell.HideWall (j, true);
									found = true;
								}
							}
						}
					}

				}
			}
		}

		void HideWalls(){

			for (int i = 0; i < cells.Count; i++) {
				if(NoiseValue(i*.13f)>.499f)
					cells [i].HideWall (0,true);
				else
					cells [i].HideWall (1,true);
			
			}
		}

		void CleanUp(){
			for (int i = 0; i < cells.Count; i++) {
				while(cells[i].GetWallCount()>4)
					cells[i].HideWall( cells [i].FindRemovableWall (), true);
				cells [i].txt.text = cells [i].GetWallCount ()+"";
			}

		}

		float NoiseValue(float val){
			float outVal = Mathf.PerlinNoise (randomSeed * val, randomSeed * val);
			return outVal;
		}

		IEnumerator hidewalls(){
			for (int i = 0; i < cells.Count; i++) {
                if (NoiseValue(i * .13f) > .499f)
					cells [i].HideWall (0,true);
				else
					cells [i].HideWall (1,true);
				yield return null;//new WaitForSeconds (.01f);
			}
			StartCoroutine( cleanUp ());
		}

		IEnumerator cleanUp(){
			for (int i = 0; i < cells.Count; i++) {
				while(cells[i].GetWallCount()>4)
					cells[i].HideWall( cells [i].FindRemovableWall (), true);
				cells [i].txt.text = cells [i].GetWallCount ()+"";
				yield return null;//new WaitForSeconds (.001f);
			}
            RemoveEnclosedSpaces();
            RemoveDuplicateWalls();
		}

	}
}
