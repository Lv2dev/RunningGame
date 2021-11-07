using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPrefeb : MonoBehaviour
{
    public float speed;
    public float limitX = -5f;
    public GameSpeedMgr speedMgr;
    public int instanceCnt = 0;
    public MapMaker maker;
    public float instanceX = -3f;
    void Start()
    {
        speedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        maker = GameObject.Find("MapMaker").GetComponent<MapMaker>();
        instanceCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speedMgr.gameSpeed;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if ((transform.position.x < -limitX) || (transform.position.y < -limitX) || (transform.position.y > limitX) || (transform.position.x > limitX))
        {
            Destroy(gameObject);
        }
        if (transform.position.x < instanceX && instanceCnt < 1)
        {
            instanceCnt++;
            maker.isInstance = true;
        }
    }
}
