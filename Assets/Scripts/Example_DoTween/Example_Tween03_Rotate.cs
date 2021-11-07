using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Example_Tween03_Rotate : MonoBehaviour
{
    public Vector3 target;
    public float tweenDuration;
    public Ease ease;
    public LoopType loopType;
    void Start()
    {
        transform.DORotate(target, tweenDuration).SetEase(ease).SetLoops(-1, loopType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
