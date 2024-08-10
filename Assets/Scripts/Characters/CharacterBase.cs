using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBase : MonoBehaviour, IJumper
{
    public enum States
    {
        Appearing,
        Running,
        Die
    }

    protected JumpController jumpController;
    protected GroundChecker groundChecker;
    protected Rigidbody2D rb;

    protected States State { get; private set; } = States.Appearing;
    
    const float APPEARING_START_Y = 7f;
    const float DIE_START_Y = 7f;
    
    

    protected virtual void Awake()
    {
        jumpController = GetComponent<JumpController>();
        groundChecker = GetComponent<GroundChecker>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Appear()
    {
        //떨어지는 위치 설정
        Vector2 appearPosition = transform.localPosition;
        appearPosition.y = APPEARING_START_Y;
        transform.localPosition = appearPosition;

        //빠르게 떨어지도록
        rb.gravityScale = 4f;
    }

    protected virtual void Update()
    {
        if (State == States.Appearing)
        {
            if (groundChecker.IsGrounded)
            {
                State = States.Running;
                rb.gravityScale = 1f;
            }
        }
    }

    public float GetJumpForce()
    {
        return jumpController.GetJumpForce();
    }

    public void Jump(float jumpForce)
    {
        if(State == States.Running)
            jumpController.Jump(jumpForce);
    }

    public float GetVelocityY()
    {
        return rb.velocity.y;
    }
}
