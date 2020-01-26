using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeArtGrid : MonoBehaviour
{

    public int XDivisions;
    public int YDivisions;
    public float size;
    public int maxSize = 3;
    public bool fillEmpty;
    public GameObject elements;
    List<GameObject> squares;
    bool[,] cells;
    public bool rebuild = true;

    void Start()
    {
        
    }

	private void Update()
	{
        if (Input.GetKey(KeyCode.A))
            rebuild = true;
        if (rebuild)
        {
            if(this.transform.childCount>0){
                for (int i = this.transform.childCount-1; i >= 0; i--)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                }
            }
            cells = new bool[XDivisions, YDivisions];
            squares = new List<GameObject>();
            Fill();
            if (fillEmpty)
                FillEmpty();
            rebuild = false;
        }
	}

	void Fill()
    {
        for (int i = 0; i < XDivisions; i++)
        {
            for (int j = 0; j < YDivisions; j++)
            {
                
                    int rSize = (int)Mathf.Round((Random.Range(1, maxSize)));
                    while (j + rSize > YDivisions || i + rSize > XDivisions)
                    {
                        rSize--;
                    }

                    if (CheckSurroundingCells(i, j, rSize))
                    {
                        Vector3 pos = new Vector3(i * size + (size * .5f), j * size + (size * .5f), 0);
                        
                        GameObject G = Instantiate(elements.transform.GetChild((int)(Random.value * elements.transform.childCount))).gameObject;
                        if (G.GetComponent<ArtGrid_BaseClass>() != null)
                            G.GetComponent<ArtGrid_BaseClass>().Init();
                        GameObject GP = new GameObject();
                        G.transform.parent = GP.transform;
                        GP.transform.localPosition = new Vector3(i * size, j * size, 0);
                        GP.transform.parent = this.transform;
                        G.transform.localPosition = new Vector3(.5f, .5f, .5f);
                        GP.transform.localScale = new Vector3(rSize, rSize, rSize);
                        //G.transform.localEulerAngles = new Vector3(Mathf.Floor(Random.value * 4) * 90, Mathf.Floor(Random.value * 4) * 90, Mathf.Floor(Random.value * 4) * 90);
                        squares.Add(G);
                        FillSurroundingCells(i, j, rSize);
                        
                    }

            }
        }
    }

    void FillEmpty()
    {
        for (int i = 0; i < XDivisions; i++)
        {
            for (int j = 0; j < YDivisions; j++)
            {
                
                if (CheckSurroundingCells(i, j, 1))
                {
                    Vector3 pos = new Vector3(i * size + (size * .5f), j * size + (size * .5f), 0.5f);     
                    GameObject G = Instantiate(elements.transform.GetChild((int)(Random.value * elements.transform.childCount))).gameObject;//, new Vector3(i * size, j * size, 0), Quaternion.identity, this.transform).gameObject;
                    if (G.GetComponent<ArtGrid_BaseClass>() != null)
                        G.GetComponent<ArtGrid_BaseClass>().Init();
                    G.transform.localScale = new Vector3(1, 1, 1);
                    G.transform.position = pos;
                    G.transform.parent = this.transform;
                    squares.Add(G);
                    FillSurroundingCells(i, j, 1);
                }

            }
        }
    }

    bool CheckSurroundingCells(int x, int y, int size)
    {
        bool emptyCells = true;
        for (int i = x; i < Mathf.Min(x + size, XDivisions); i++)
        {
            for (int j = y; j < Mathf.Min(y + size, YDivisions); j++)
            {
                if (cells[i, j])
                {
                    emptyCells = false;
                }
            }
        }

        return emptyCells;
    }

    void FillSurroundingCells(int x, int y, int size)
    {
        for (int i = x; i < Mathf.Min(x + size, XDivisions); i++)
        {
            for (int j = y; j < Mathf.Min(y + size, YDivisions); j++)
            {
               
                if (!cells[i, j])
                {
                    cells[i, j] = true;
                }

            }
        }
    }
}
