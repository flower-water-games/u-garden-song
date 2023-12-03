using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Bucket : InteractableObject
{
    public GameObject BucketVisual;
    public override void Use()
    {
        if (isBeingUsed) return;
        Debug.Log("Bucket used");
        // start coroutine that for 2 seconds, the rotation of the object will be x+=80
        StartCoroutine(RotateObject());

    }
    
    public bool isBeingUsed = false;
    public float pourPause = 2.0f;
    IEnumerator RotateObject()
    {
        // rotate object
        isBeingUsed = true;
        LeanTween.rotateX(BucketVisual, 80, .2f);
        transform.rotation = Quaternion.Euler(80, 0, 0);
        yield return new WaitForSeconds(pourPause);
        // wait 2 seconds
        LeanTween.rotateX(BucketVisual, 0, .2f);
        yield return new WaitForSeconds(.5f);
        isBeingUsed = false;
    }

    private void Start()
    {
        Debug.Log("bucket vibes");
    }
}

