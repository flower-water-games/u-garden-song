using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    private float saturationLevel = 0f;
    [SerializeField] private float saturationLimit = 100f;
    
    public void OnSoilCollision()
    {
        if (saturationLevel >= saturationLimit)
        {
            Debug.Log("Soil is saturated");
            foreach (GameObject obj in ScaleMe)
            {
                // add some variation to the scale
                LeanTween.scale(obj, new Vector3(1, 1, 1), .1f);
            }

            saturationLevel = 0f;
            return;
        }
        saturationLevel += 1f;
        ScaleUp();
    }

    public List<GameObject> ScaleMe;
    // scale up an object based on the level comapred to the limit
    public void ScaleUp()
    {
        // current scale of object is 1
        // max scale is 3
        // based on the saturation level / saturation limit, scale up the object between 1 to 3
        
        float satRatio = saturationLevel / saturationLimit;
        float scale = Mathf.Lerp(1, 3.5f, satRatio);

        foreach (GameObject obj in ScaleMe)
        {
            // add some variation to the scale
            scale += Random.Range(-.4f, .4f);
            LeanTween.scale(obj, new Vector3(scale, scale, scale), .1f);
        }
        //ScaleMe.transform.localScale = new Vector3(scale, scale, scale); 
    }

}
