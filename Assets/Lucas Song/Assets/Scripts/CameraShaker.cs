using System;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public Boolean shakeCamera = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeCamera)
        {
            transform.localPosition = new Vector3(UnityEngine.Random.Range(-1,1),UnityEngine.Random.Range(-1,1),UnityEngine.Random.Range(-1,1))*0.05f;
        }
    }
}
