using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public GameObject honk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter()
    {
        AudioSource audioSource = honk.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
