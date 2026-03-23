using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource thrustSound;
    
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    
    
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

            if (!thrustSound.isPlaying)
            {
                thrustSound.Play();
            }
        }
        else if (!thrust.IsPressed())
        {
            thrustSound.Stop();
        }
    }

    private void ProcessRotation()
    {
        var rotationInput = rotation.ReadValue<float>();

        switch (rotationInput)
        {
            case < 0:
                ApplyRotation(rotationSpeed);
                break;
            case > 0:
                ApplyRotation(-rotationSpeed);
                break;
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        
        transform.Rotate(Vector3.forward * (rotationThisFrame * Time.fixedDeltaTime));
        
        rb.freezeRotation = false;
    }

    private void OnDisable()
    {
        thrust.Disable();
        rotation.Disable();
    }
}
