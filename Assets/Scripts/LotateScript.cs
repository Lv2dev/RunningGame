using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotateScript : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(speed, 0, 0);
    }
}
