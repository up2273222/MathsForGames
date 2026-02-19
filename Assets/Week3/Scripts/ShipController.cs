using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [Header("Tuning")]
    public float moveSpeed = 5f; // units/sec
    public float lookSensitivity = 0.15f; // degrees per mouse delta unit
    public float pitchClamp = 80f; // degrees

    // Input values set by PlayerInput (Send Messages)
    private Vector2 moveInput; // x=strafe, y=forward
    private Vector2 lookInput; // mouse delta


    // We store angles in degrees for easier tuning/clamping
    private float yawDeg;
    private float pitchDeg;

    private Vector3 moveDir;

    // Called automatically by PlayerInput for action "Move"
   public void OnMove(InputValue value)
    {
      moveInput = value.Get<Vector2>();
    }

    // Called automatically by PlayerInput for action "Look"
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }


    private void Update()

    {
        // TODO (Part B): Implement using the steps below in the workshop.

        // Leave everything else in this file unchanged.

        yawDeg += lookInput.x * lookSensitivity;

        pitchDeg += lookInput.y * lookSensitivity;

        pitchDeg = Mathf.Clamp(pitchDeg, -pitchClamp, pitchClamp);

        //Now we’ll use our MFGCore library for movement before our last line is:

       

        float yawRad = MathCore.DegToRad(yawDeg);
        float pitchRad = MathCore.DegToRad(pitchDeg);


        Vector3 up = Vector3.up;
        Vector3 fwd = MathCore.ForwardFromYawPitch(yawRad, pitchRad);
        Vector3 right = MathCore.Cross(up, fwd);


        moveDir = MathCore.AddVector(MathCore.ScaleVector(fwd, moveInput.y), MathCore.ScaleVector(right, moveInput.x));

       
        

        gameObject.transform.position += MathCore.MoveStep(fwd, moveSpeed, Time.deltaTime);
        transform.rotation = Quaternion.Euler(pitchDeg, yawDeg, 0f);
    }

   

}
