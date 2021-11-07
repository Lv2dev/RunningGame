using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RotateObject : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float rotSpeed;
    public Ease ease;
    public LoopType loopType;
    void Start()
    {
        //transform.DORotate(new Vector3(x, y, z), 2f).SetLoops(-1, loopType).SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x* rotSpeed * Time.deltaTime, y* rotSpeed * Time.deltaTime, z* rotSpeed * Time.deltaTime);
    }
}
