using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public Animator _animator;
    Vector2 velocity;
    


    void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        _animator.SetFloat("Speed",velocity.y);
        transform.Translate(velocity.x, 0, velocity.y);
        
    }
}
