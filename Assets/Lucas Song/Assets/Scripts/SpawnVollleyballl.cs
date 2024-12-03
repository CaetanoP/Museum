using UnityEngine;

public class SpawnVollleyballl : MonoBehaviour
{
    public float isTriggered = 0;
    public bool touchingCollider = false;
    public Transform ballSpawn;
    public GameObject volleyBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (isTriggered == 0)
        {
            isTriggered = 1;
            Instantiate(volleyBall, ballSpawn.position, Quaternion.identity);
            touchingCollider = true;
            Debug.Log("EnteredTriggerArea");
        }
    }
}
