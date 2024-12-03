using UnityEngine;

public class PlaySound_Shark : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
        void OnTriggerExit()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
