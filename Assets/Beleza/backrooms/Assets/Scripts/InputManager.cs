using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput PlayerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor Motor;
    private PlayerLook Look;

    private void FixedUpdate() {
        Motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate() {
        Look.ProcessLook(onFoot.Look.ReadValue<Vector2>()); 
    }

    private void Awake() {
        PlayerInput = new PlayerInput();
        onFoot = PlayerInput.OnFoot;
        Motor = GetComponent<PlayerMotor>();
        Look  = GetComponent<PlayerLook>();
        onFoot.Jump.performed   += ctx => Motor.Jump();
        onFoot.Sprint.performed += ctx => Motor.Sprint();
        onFoot.Crouch.performed += ctx => Motor.Crouch();
    }

    private void OnEnable() {
        onFoot.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}
