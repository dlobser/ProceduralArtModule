using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

	void Start () {
        
                Mesh mesh = new Mesh();
                GetComponent<MeshFilter>().mesh = mesh;

                Vector3[] vertices = new Vector3[4];

                vertices[0] = new Vector3(-1, 1, 0);
                vertices[1] = new Vector3(1, 1, 0);
                vertices[2] = new Vector3(1, -1, 0);
                vertices[3] = new Vector3(-1, -1, 0);

                int[] triangles = new int[] { 0, 1, 3, 3, 1, 2 };
                Vector2[] uvs = new Vector2[]{
                        new Vector2(0,1),
                        new Vector2(1,1),
                        new Vector2(1,0),
                        new Vector2(0,0)
                };

                mesh.vertices = vertices;
                mesh.triangles = triangles;
                mesh.uv = uvs;

	}
	
}
