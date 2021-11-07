using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMapPrefab : MonoBehaviour
{
    public float speed;
    public float limitX = -5f;
    public float stopX = 0;
    public float curtime;
    public float cooltime = 1f;
    public GameSpeedMgr speedMgr;
    public ChildRotate childMap;
    public bool isRotate;
    public int instanceCnt = 0;
    public MapMaker maker;
    public float instanceX = -3f;
    public PlayerController player;
    public int rotateCnt = 0;
    void Start()
    {
        speedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        maker = GameObject.Find("MapMaker").GetComponent<MapMaker>();
        isRotate = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        instanceCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speedMgr.gameSpeed;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if((transform.position.x < stopX))
        {
            isRotate = true;
        }
        if ((transform.position.x < -limitX) || (transform.position.y < -limitX) || (transform.position.y > limitX) || (transform.position.x > limitX))
        {
            Destroy(gameObject);
        }
        if(transform.position.x < instanceX && instanceCnt < 1)
        {
            instanceCnt++;
            maker.isInstance = true;
        }
        if (transform.position.x < 20f && rotateCnt < 1 && transform.position.x > 3f)
        {
            player.isLeftRotate = true;
        }
        if (transform.position.x < 1 && rotateCnt < 1 && player.isPass == false && player.isLeftRotate && player.isGod == false)
        {
            player.jumpState = PlayerController.JUMPSTATE.HIT;
            player.playerHP -= 2;
            player.isPass = false;
            player.isLeftRotate = false;
            rotateCnt++;
        }
        else if(transform.position.x < 1 && rotateCnt < 1 && player.isPass && player.isLeftRotate)
        {
            player.isPass = false;
            player.isLeftRotate = false;
            rotateCnt++;
        }
        else if (transform.position.x < 1 && rotateCnt < 1 && player.isGod)
        {
            player.isPass = false;
            player.isLeftRotate = false;
            rotateCnt++;
        }
    }
}
