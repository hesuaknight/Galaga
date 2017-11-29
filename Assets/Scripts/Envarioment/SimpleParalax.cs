using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleParalax : MonoBehaviour {

    public Vector2 speedParalax;
    Material mat;
	void Awake ()
    {
        mat = GetComponent<Renderer>().material;
	}
	
	void Update ()
    {
        mat.mainTextureOffset += speedParalax * Time.deltaTime;
	}
}
