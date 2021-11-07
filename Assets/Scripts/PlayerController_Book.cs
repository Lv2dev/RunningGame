using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Book : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float jumpPower = 50f;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * jumpPower);
        }        
    }
}
