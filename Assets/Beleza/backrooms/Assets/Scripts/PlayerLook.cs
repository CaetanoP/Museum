using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    [SerializeField] private float xRotation, xSensitivity, ySensitivity;

    public void ProcessLook(Vector2 Input) {
        float xMouse = Input.x, yMouse = Input.y;
        xRotation -= yMouse * ySensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        Cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (xMouse * xSensitivity * Time.deltaTime));
    }
}
