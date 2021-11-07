using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaker : MonoBehaviour
{
    public GameObject boosterPrefab; 
    public GameObject coinPrefab;
    public GameObject itemPrefab;
    public GameObject[] itemsPrefabs;
    public float curTime;
    public float coolTime = 2f;
    public int boosterPer;
    public Transform[] itemPos;
    public Material[] itemMaterials;
    public GameSpeedMgr gameSpeedMgr;
    public bool isMake;
    void Start()
    {
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
        isMake = true;
    }

    void Update()
    {
        if (gameSpeedMgr.gameSpeed != 0)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime && isMake)
            {
                RandomPosition();
                int itemRnd = Random.Range(0, 100);

                if (itemRnd < boosterPer)
                {
                    GameObject item = Instantiate(boosterPrefab);
                    item.name = "Booster";
                    item.transform.position = gameObject.transform.position;
                    item.transform.rotation = gameObject.transform.rotation;
                }
                else
                {
                    int rndItem = Random.Range(0, 100);
                    if (rndItem > 10)
                    {
                        GameObject item = Instantiate(coinPrefab);
                        item.name = "Coin";
                        item.transform.position = gameObject.transform.position;
                        item.transform.rotation = gameObject.transform.rotation;
                    }
                    else
                    {
                        GameObject item = Instantiate(itemPrefab);
                        item.name = "Item";
                        item.transform.position = gameObject.transform.position;
                        item.transform.rotation = gameObject.transform.rotation;
                    }
                }
                curTime = 0;
            }
        }
    }

    void RandomPosition()
    {
        int rnd = Random.Range(0, itemPos.Length);
        transform.position = itemPos[rnd].position;
    }
}
