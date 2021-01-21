using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;
    Rigidbody _rigidBody;
    public Animator _animator;
    public float jumpStrength = 2;
    public event System.Action Jumped;


    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (groundCheck.isGrounded)
        {
            _animator.SetBool("Jump", false);
        }

        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            _animator.SetBool("Jump", true);
            _rigidBody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
            
        }
    }
}
