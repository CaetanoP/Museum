using JetBrains.Annotations;
using UnityEngine;

public class TitanicMovement : MonoBehaviour
{
    public GameObject titanic;
    public Transform posicao;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        titanic.transform.position = Vector3.MoveTowards(titanic.transform.position, posicao.transform.position, speed);
    }
}
