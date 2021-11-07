using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime = 2f;
    public GameSpeedMgr gameSpeedMgr;
    void Start()
    {
        RandomCoolTime();
        gameSpeedMgr = GameObject.Find("GameSpeedMgr").GetComponent<GameSpeedMgr>();
    }

    void Update()
    {
        if(gameSpeedMgr.gameSpeed != 0)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = gameObject.transform.position;
                enemy.transform.rotation = gameObject.transform.rotation;
                curTime = 0;
                RandomCoolTime();
            }
        }        
    }

    void RandomCoolTime()
    {
        coolTime = Random.Range(1, 6);
    }
}
