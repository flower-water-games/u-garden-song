using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Bucket : InteractableObject
{
    public override void Use()
    {
        Debug.Log("Bucket used");
    }

    private void Start()
    {
        Debug.Log("vibes");
    }
}

