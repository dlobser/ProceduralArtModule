using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeArt : MonoBehaviour
{
    public GameObject[] parts;
    List<GameObject> elements;

    public int amount;
    public float spread;

    public float gravity;
    public float explodeForce;

    public float minScale;
    public float maxScale;

    bool solve = true;

    void Start()
    {
        
        elements = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            elements.Add(Instantiate(
                parts[Random.Range(0, parts.Length)], 
                Random.insideUnitSphere * spread, 
                Quaternion.identity, 
                this.transform));
            
            float randomScale = Random.Range(minScale, maxScale);
            elements[i].transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            solve = !solve;
        }
        if (solve)
        {
            for (int i = 0; i < amount; i++)
            {
                elements[i].GetComponent<Rigidbody>().isKinematic = false;

                Vector3 dir = Vector3.zero - elements[i].transform.position;
                elements[i].GetComponent<Rigidbody>().AddForce(dir * gravity);
                Vector3 vel = elements[i].GetComponent<Rigidbody>().velocity * .05f;
                Color velocityColor = new Color(vel.x, vel.y, vel.z);
                MeshRenderer[] renderers = elements[i].GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in renderers)
                    r.material.SetColor("_EmissionColor", velocityColor);
            }
            if (Input.GetMouseButtonDown(0))
            {

                Vector3 forcePosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));

                for (int i = 0; i < amount; i++)
                {
                    float dist = Vector3.Distance(elements[i].transform.position, forcePosition);
                    Vector3 dir = (elements[i].transform.position - forcePosition) / dist;
                    elements[i].GetComponent<Rigidbody>().AddForce(dir * explodeForce);
                }

            }
        }
        else{
            for (int i = 0; i < amount; i++)
            {
                elements[i].GetComponent<Rigidbody>().isKinematic = true;

            }
        }
    }
}
