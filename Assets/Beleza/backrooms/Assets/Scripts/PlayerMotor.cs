using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool isGrounded, Sprinting, lerpCrouch, Crouching;
    private float Speed, CrouchTimer;
    [SerializeField] private float HighSpeed, LowSpeed, JumpHeight, Height, CrouchingHeight, Gravity;

    private void Start() {
        Controller = GetComponent<CharacterController>();
        Sprinting = false; lerpCrouch = false; Crouching = false;
        CrouchTimer = 0;
        Speed = LowSpeed;
        Controller.height = Height;
    }

    private void Update() {
        isGrounded = Controller.isGrounded;
        if (lerpCrouch) {
            CrouchTimer += Time.deltaTime;
            float p = CrouchTimer / 1; p = p * p;
            if (Crouching) {
                Controller.height = Mathf.Lerp(Controller.height, CrouchingHeight, p);
            }
            else {
                Controller.height = Mathf.Lerp(Controller.height, Height, p);
            }
            if (p > 1) {
                lerpCrouch = false;
                CrouchTimer = 0;
            }
        }
    }

    public void ProcessMove(Vector2 Input) {
        Vector3 MoveDir = Vector3.zero;
        MoveDir.x = Input.x; MoveDir.z = Input.y;
        Controller.Move(transform.TransformDirection(MoveDir * Speed * Time.deltaTime));
        if(isGrounded && PlayerVelocity.y < 0)
              PlayerVelocity.y  = Gravity * Time.deltaTime;
        else  PlayerVelocity.y += Gravity * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);
    }

    public void Jump() {
        if(!isGrounded) return;
        PlayerVelocity.y = Mathf.Sqrt(-1 * JumpHeight * JumpHeight * Gravity);
    }

    public void Sprint() {
        Sprinting = !Sprinting;
        if (Sprinting) Speed = HighSpeed;
        else           Speed = LowSpeed;
    }

    public void Crouch() {
        Crouching = !Crouching;
        CrouchTimer = 0;
        lerpCrouch = true;
    }
}
