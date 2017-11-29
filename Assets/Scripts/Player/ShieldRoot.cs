using System.Collections.Generic;
using UnityEngine;

public class ShieldRoot : MonoBehaviour {

    public float rotationForce;
    private List<Transform> shields = new List<Transform>();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            shields.Add(transform.GetChild(i).transform);
            shields[i].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        transform.Rotate(0, rotationForce, 0 * Time.deltaTime);
    }
    public void ActiveNewShield()
    {
        for (int i = 0; i < shields.Count; i++)
        {
            if (!shields[i].gameObject.activeInHierarchy)
            {
                shields[i].gameObject.SetActive(true);
                break;
            }
        }
    }
}
