using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class SharkMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    private int waypointIndex = 0;
    public float rotationSpeed = 180f;
    private Vector3 movementDirection;
	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}
	private void Update () {
        Move();
	}
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        movementDirection = waypoints[waypointIndex].transform.position - transform.position;

        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);   

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex > waypoints.Length - 1)
        {
            waypointIndex = 0;
        }
    }
}