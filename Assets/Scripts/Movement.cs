using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;
    [SerializeField]private Rigidbody rb;
    
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 10f;
    
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    private void ProcessRotation()
    {
        var rotationInput = rotation.ReadValue<float>();
        
        
    }

    private void OnDisable()
    {
        thrust.Disable();
        rotation.Disable();
    }
}
