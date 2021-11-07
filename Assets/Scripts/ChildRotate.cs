using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotate : MonoBehaviour
{
    public LeftMapPrefab left;
    public RightMapPrefab right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(left.isRotate)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 15.0f * Time.deltaTime);
        }
        if(right.isRotate)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), 15.0f * Time.deltaTime);
        }
    }
}
