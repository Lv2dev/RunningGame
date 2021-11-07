using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenScale : MonoBehaviour
{
    public Vector3 targetScale;
    public float tweenDuration;
    public Ease ease;
    public LoopType loopType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartTweenScale()
    {
        transform.DOScale(targetScale, tweenDuration).SetEase(ease);
    }
}
