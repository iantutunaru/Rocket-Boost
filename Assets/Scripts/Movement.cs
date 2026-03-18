using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputAction thrust;
    [SerializeField]private Rigidbody rb;
    
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 10f;
    
    private void OnEnable()
    {
        thrust.Enable();
    }

    private void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * (moveSpeed * Time.fixedDeltaTime));
        }
    }
    
    private void OnDisable()
    {
        thrust.Disable();
    }
}
