using JetBrains.Annotations;
using UnityEngine;

public class Kraken_Move : MonoBehaviour
{
    public Transform posicao;
    private float speed = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicao.transform.position, speed);
    }
}