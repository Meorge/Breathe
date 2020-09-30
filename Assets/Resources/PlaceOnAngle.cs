using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnAngle : MonoBehaviour
{
    public float angle = 0f;

    public float radius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float radAngle = angle * Mathf.Deg2Rad;
        Vector3 pos = new Vector3(Mathf.Cos(radAngle) * radius, Mathf.Sin(radAngle) * radius, transform.localPosition.z);
        transform.localPosition = pos;
    }
}
