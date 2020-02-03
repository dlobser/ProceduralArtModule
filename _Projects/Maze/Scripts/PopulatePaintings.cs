using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulatePaintings : MonoBehaviour
{
  
    Painting[] paintings;
    Texture2D[] textList;
    Sprite[] spriteList;
    string[] files;
    string[] descriptions;
    public string path;
    public bool rebuild;
    public bool repeatPaintings = true;

    public Material textMaterial;
    public Font font;

	private void Update()
	{
        if(rebuild){
            
            Populate();
            rebuild = false;
        }
	}

	public void Populate(){
        StartCoroutine(LoadImages());
    }

    string CheckForDescription(string file){
        string r = "";
        string f = file.Remove(file.Length - 4);
        for (int i = 0; i < descriptions.Length; i++)
        {
            if(f.Equals(descriptions[i].Remove(descriptions[i].Length-4))){
                string pathTemp = "file://" + descriptions[i];
                WWW www = new WWW(pathTemp);
                r = www.text;
                //print(r);
            }
        }
        return r;
    }

    private IEnumerator LoadImages()
    {
        yield return new WaitForSeconds(.1f);

        files = System.IO.Directory.GetFiles(Application.dataPath + path, "*.png");
        descriptions = System.IO.Directory.GetFiles(Application.dataPath + path, "*.txt");

        paintings = FindObjectsOfType<Painting>();
        //print(paintings.Length);
        foreach (Painting p in paintings)
            p.CheckRaycast();

        textList = new Texture2D[files.Length];
        spriteList = new Sprite[files.Length];
        string[] descriptionList = new string[files.Length];
        int dummy = 0;

        foreach (string tstring in files)
        {
            string pathTemp = "file://" + tstring;
            WWW www = new WWW(pathTemp);
            yield return www;
            Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(texTmp);
            spriteList[dummy] = Sprite.Create(texTmp, new Rect(0, 0, texTmp.width, texTmp.height), Vector2.one*.5f, texTmp.width);//new Vector2(texTmp.width*.5f,texTmp.height*.5f));
            textList[dummy] = texTmp;

            string d = CheckForDescription(tstring);
            descriptionList[dummy] = d;

            dummy++;


        }
        int j = 0;
        for (int i = 0; i < paintings.Length; i++)
        {
            if(paintings[i]!=null){
                
                paintings[i].GetComponent<SpriteRenderer>().sprite = spriteList[j];// textList[j]);
                paintings[i].gameObject.isStatic = false;
                float aspect = (float)textList[j].width / (float)textList[j].height;
                float s = 1/(float)textList[j].width;
                float t = 1/(float)textList[j].height * s;
                paintings[i].gameObject.isStatic = true;

                if (descriptionList[j].Length > 0)
                {
                    GameObject dd = new GameObject();
                    TextMesh text = dd.AddComponent<TextMesh>();

                    text.fontSize = 50;
                    string tempString = descriptionList[j].Remove(0, 1);
                    text.text = tempString;
                    text.font = font;
                    dd.GetComponent<MeshRenderer>().material = textMaterial;
                    dd.transform.parent = paintings[i].transform;
                    dd.transform.localScale = Vector3.one * .005f;
                    dd.transform.localEulerAngles = Vector3.zero;
                    dd.transform.localPosition = new Vector3(.6f, -.2f, 0);
                }

                j++;
                if (j >= textList.Length)
                {
                    j = 0;
                    if(!repeatPaintings)
                        i = paintings.Length;
                }
            }
        }

    }
   
}
