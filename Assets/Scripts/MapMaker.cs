using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    public GameObject leftMapPrefeb; 
    public GameObject rightMapPrefeb;
    public GameObject frontMapPrefeb;
    public float curTime;
    public float curtime1;
    public float coolTime = 2f;
    public GameSpeedMgr gameSpeedMgr;
    public bool isInstance = false;
    void Start()
    {
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        isInstance = false;
    }

    void Update()
    {
        curtime1 = 8 / gameSpeedMgr.gameSpeed;
        if (gameSpeedMgr.gameSpeed != 0)
        {
            if (isInstance)
            {
                int itemRnd = Random.Range(1, 99);

                if (itemRnd < 33)
                {
                    GameObject item = Instantiate(leftMapPrefeb);
                    item.name = "LeftMap";
                    item.transform.position = gameObject.transform.position;
                    item.transform.rotation = gameObject.transform.rotation;
                }
                else if(itemRnd >= 33 && itemRnd <66)
                {
                    GameObject item = Instantiate(frontMapPrefeb);
                    item.name = "FrontMap";
                    item.transform.position = gameObject.transform.position;
                    item.transform.rotation = gameObject.transform.rotation;
                }
                else
                {
                    GameObject item = Instantiate(rightMapPrefeb);
                    item.name = "RightMap";
                    item.transform.position = gameObject.transform.position;
                    item.transform.rotation = gameObject.transform.rotation;
                }
                isInstance = false;
            }
        }
    }
}
