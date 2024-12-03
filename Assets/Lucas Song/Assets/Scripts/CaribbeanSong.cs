using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Boolean check = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter()
    {
        if (check)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            check = false;
        }
    }
}
