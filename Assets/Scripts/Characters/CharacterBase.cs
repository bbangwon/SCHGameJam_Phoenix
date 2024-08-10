using UnityEngine;

public class CharacterBase : MonoBehaviour, IJumper
{
    public enum States
    {
        None,
        Appearing,
        Running,
        Hot6,
        Die
    }

    protected JumpController jumpController;
    protected GroundChecker groundChecker;
    protected TriggerChecker triggerChecker;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
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

    public bool IsAlive => State != States.None && State != States.Die;
    
    

    protected virtual void Awake()
    {
        jumpController = GetComponent<JumpController>();
        groundChecker = GetComponent<GroundChecker>();
        triggerChecker = GetComponent<TriggerChecker>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    public void Appear()
    {
        State = States.Appearing;

        if(animator != null)
            animator.enabled = false;
    }

    protected virtual void Update()
    {
        if (groundChecker.IsGrounded)
        {
            if(State == States.Appearing)
            {
                State = States.Running;
            }
        }

        //화면 밖으로 나가면 사망처리
        if(State == States.Running) 
        {
            if(triggerChecker.IsDeadZoneTriggered)
            {
                State = States.Die;
                return;
            }

            if(animator != null)
                animator.SetBool("IsJumping", !groundChecker.IsGrounded);
        }
    }

    public float GetJumpForce()
    {
        return jumpController.GetJumpForce();
    }

    public void Jump(float jumpForce)
    {
        if(State == States.Running)
        {
            jumpController.Jump(jumpForce);
        }
    }

    public float GetVelocityY()
    {
        return rb.velocity.y;
    }

    public void TakeHot6()
    {
        State = States.Hot6;

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
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
        if (animator != null)
        {
            animator.enabled = true;
            animator.Rebind();
        }

        rb.gravityScale = 1f;
        triggerChecker.StartCheck();
    }

    protected virtual void Die()
    {
        animator.enabled = false;
        spriteRenderer.enabled = false;
        triggerChecker.StopCheck();
    }

    protected virtual void Hot6()
    {
        //Hot6에 탔을때
    }


}
