using UnityEngine;

public class TriggerBall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Volley")
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }
}
