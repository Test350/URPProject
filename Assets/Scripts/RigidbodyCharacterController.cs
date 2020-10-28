using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Collider col;

    [SerializeField]
    PhysicMaterial stopPhysicMat;
    [SerializeField]
    PhysicMaterial movePhysicMat;

    Vector2 input;
    
    [SerializeField]
    float acceleration = 10;
    [SerializeField]
    float maxSpeed = 2;

    [SerializeField, Range(0, 1)]
    float turnSpeed = 0.5f; 

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<Collider>();
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 inputDir = new Vector3(input.x, 0, input.y);
        inputDir = inputDir.normalized;

        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;

        Quaternion camLocalRotation = Quaternion.LookRotation(camForward);
        Vector3 camRelativeInputDir = camLocalRotation * inputDir;
        

        col.material = inputDir.sqrMagnitude > 0 ? movePhysicMat : stopPhysicMat;

        if(rb.velocity.sqrMagnitude < maxSpeed) 
            rb.AddForce(camRelativeInputDir * acceleration, ForceMode.Acceleration);

        if(camRelativeInputDir.sqrMagnitude > 0 )
        {
            Quaternion targetRotation = Quaternion.LookRotation(camRelativeInputDir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, turnSpeed);
        }
            

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);


    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        input = context.ReadValue<Vector2>();
    }
    


}
