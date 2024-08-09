using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.position.x, jumpForce);
    }
}
