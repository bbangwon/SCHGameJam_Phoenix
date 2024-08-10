using UnityEngine;

public class Player : CharacterBase
{
    ObstacleChecker obstacleChecker;

    protected override void Awake()
    {
        base.Awake();
        obstacleChecker = GetComponent<ObstacleChecker>();
    }

    protected override void Update()
    {
        base.Update();

        if (obstacleChecker.IsTriggered)
        {
            UIManager.Instance.SetTriggeredCount(obstacleChecker.TriggeredCount);

            //장애물에 닿음
            //사망 처리?
        }    
    }

    void OnJump()
    {
        if(State == States.Running)
        {
            if (groundChecker.IsGrounded)
            {
                CharacterManager.Instance.Jump();
            }
            else
            {
                GameManager.Instance.LaunchMissile();
            }
        }
    }

    public Vector2 CenterPosition => transform.localPosition + Vector3.up * 0.5f;
}
