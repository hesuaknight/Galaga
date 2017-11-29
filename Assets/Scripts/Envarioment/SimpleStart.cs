using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStart : MonoBehaviour {

    Light l;
    public float duration = 1;
    public float limit = 4;
    public float movementSpeed;
    private float offset = 5;
    public Vector3 initialPos;
    Transform player;
	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        l = GetComponent<Light>();
        initialPos = transform.position;     
	}
	
	void Update ()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F * limit;
        //Debug.Log(amplitude);
        l.intensity = amplitude;

        transform.position += new Vector3(0, -1, 0) * movementSpeed * Time.deltaTime;
        checkLimits();
    }

    void checkLimits()
    {
        if (transform.position.y- offset < player.transform.position.y)
        {
            transform.position = initialPos;
        }
    }

}
