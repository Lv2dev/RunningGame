using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroRolling : MonoBehaviour
{
    public Vector3 originPos;
    public float speed = 0f;
    public float limitX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (transform.position.z > limitX)
        {
            transform.position = originPos;
        }
    }
}
