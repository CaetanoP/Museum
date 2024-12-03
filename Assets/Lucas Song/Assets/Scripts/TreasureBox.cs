using System;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject camer;
    public GameObject kraken1;
    public GameObject kraken2;
    public GameObject kraken3;
    public GameObject kraken4;
    public GameObject kraken5;
    public GameObject kraken6;
    public Transform posicao1;
    public Transform posicao2;
    public Transform posicao3;
    public Transform posicao4;
    public Transform posicao5;
    public Transform posicao6;
    private Boolean verification = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        CameraShaker cam = camer.GetComponent<CameraShaker>();

        Animator anim = GetComponent<Animator>();
        anim.SetBool("OpenChest", true);
        if (verification)
        {
            Instantiate(kraken1, posicao1.position - new Vector3(0, 500, 0), Quaternion.identity);
            Instantiate(kraken2, posicao2.position - new Vector3(0, 500, 0), Quaternion.identity);
            Instantiate(kraken3, posicao3.position - new Vector3(0, 500, 0), Quaternion.identity);
            Instantiate(kraken4, posicao4.position - new Vector3(0, 500, 0), Quaternion.identity);
            Instantiate(kraken5, posicao5.position - new Vector3(0, 500, 0), Quaternion.identity);
            Instantiate(kraken6, posicao6.position - new Vector3(0, 500, 0), Quaternion.identity);

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            cam.shakeCamera = true;

            verification = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("OpenChest", false);
    }
}
