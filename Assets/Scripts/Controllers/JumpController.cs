using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float GetJumpForce()
    {
        return rb.velocity.y;
    }

    public void Jump(float force)
    {
        rb.velocity = Vector2.up * force;
    }
}
