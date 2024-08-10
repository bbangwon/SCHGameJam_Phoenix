using UnityEngine;

public class CharacterBase : MonoBehaviour, IJumper
{
    public enum States
    {
        None,
        Appearing,
        Running,
        Die
    }

    protected JumpController jumpController;
    protected GroundChecker groundChecker;
    protected TriggerChecker triggerChecker;
    protected Rigidbody2D rb;

    protected States state = States.Appearing;

    public States State { 
        get => state; 
        protected set
        {
            state = value;

            switch (state)
            {
                case States.Appearing:
                    Appearing();
                    break;
                case States.Running:
                    Running();
                    break;
                case States.Die:
                    Die();
                    break;
                default:
                    break;
            }
        }
    }
    
    const float APPEARING_START_Y = 7f;
    const float DIE_START_Y = 7f;
    
    

    protected virtual void Awake()
    {
        jumpController = GetComponent<JumpController>();
        groundChecker = GetComponent<GroundChecker>();
        triggerChecker = GetComponent<TriggerChecker>();

        rb = GetComponent<Rigidbody2D>();
    }

    public void Appear()
    {
        State = States.Appearing;
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

        //화면 밖으로 나가면 사망처리
        if(State == States.Running && triggerChecker.IsDeadZoneTriggered) 
        {
            State = States.Die;
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

    protected virtual void Appearing()
    {
        //떨어지는 위치 설정
        Vector2 appearPosition = transform.localPosition;
        appearPosition.y = APPEARING_START_Y;
        transform.localPosition = appearPosition;

        //빠르게 떨어지도록
        rb.gravityScale = 4f;
    }

    protected virtual void Running()
    {
        rb.gravityScale = 1f;
        triggerChecker.StartCheck();
    }

    protected virtual void Die()
    {
        triggerChecker.StopCheck();
    }
}
