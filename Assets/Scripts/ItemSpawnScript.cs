using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnScript : MonoBehaviour
{
    public GameObject coin;
    public GameObject booster;
    public GameObject btm;
    public GameObject top;
    public GameObject heal;
    // Start is called before the first frame update
    void Start()
    {
        int enemyRnd = Random.Range(1, 100);
        if(enemyRnd < 10)
        {
            var oobj = GameObject.Instantiate(btm, transform.position - new Vector3(0, 4f, 0), transform.rotation);
            oobj.transform.parent = transform;
            
            int itemRnd = Random.Range(1, 10);
            if(itemRnd < 3)
            {
                var oobj1 = GameObject.Instantiate(booster, transform.position - new Vector3(0, 2f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
            else
            {
                var oobj1 = GameObject.Instantiate(coin, transform.position - new Vector3(0, 2f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
        }
        else if(enemyRnd > 90)
        {
            var oobj = GameObject.Instantiate(top, transform.position - new Vector3(0, 3f, 0), transform.rotation);
            oobj.transform.parent = transform;
            int itemRnd = Random.Range(1, 10);
            if (itemRnd < 3)
            {
                var oobj1 = GameObject.Instantiate(booster, transform.position - new Vector3(0, 4f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
            else
            {
                var oobj1 = GameObject.Instantiate(coin, transform.position - new Vector3(0, 4f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
        }
        else
        {
            int itemRnd = Random.Range(0, 100);
            if (itemRnd < 40)
            {
                var oobj1 = GameObject.Instantiate(booster, transform.position - new Vector3(0, 3.5f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
            else if(itemRnd > 90)
            {
                var oobj1 = GameObject.Instantiate(heal, transform.position - new Vector3(0, 3.5f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
            else
            {
                var oobj1 = GameObject.Instantiate(coin, transform.position - new Vector3(0, 3.5f, 0), transform.rotation);
                oobj1.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
