using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    Transform groundChecker;

    [SerializeField]
    LayerMask groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        //Ground Check
        IsGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.1f, groundLayer);
    }
}
