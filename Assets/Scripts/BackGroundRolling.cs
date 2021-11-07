using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRolling : MonoBehaviour
{
    public Vector3 originPos;
    public float speed;
    public float limitX;
    public GameSpeedMgr speedMgr;
    void Start()
    {
        speedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = speedMgr.gameSpeed;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -limitX)
        {
            transform.position = originPos;
        }
    }
}
