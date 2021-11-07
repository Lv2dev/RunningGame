using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Example_Tween01 : MonoBehaviour
{
    public Vector3 targetPos;
    public float tweenDuration;
    public Ease ease;
    public LoopType loopType;
    void Start()

    {
        transform.DOMove(targetPos, tweenDuration).SetLoops(-1, loopType).SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RePlay()
    {

    }
}
