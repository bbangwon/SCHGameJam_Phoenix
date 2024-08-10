using UnityEngine;

public class Player : CharacterBase
{
    TriggerChecker triggerChecker;

    protected override void Awake()
    {
        base.Awake();
        triggerChecker = GetComponent<TriggerChecker>();
    }

    protected override void Update()
    {
        base.Update();

        if (triggerChecker.IsObstacleTriggered)
        {
            //UIManager.Instance.SetTriggeredCount(triggerChecker.ObstacleTriggeredCount);

            //장애물에 닿음
            //사망 처리?
        }

        if(triggerChecker.TriggeredMissile != null)
        {
            if(State != States.Die)
                State = States.Die;

            //미사일 따라 날라감
            DieFromMissile();
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

    void DieFromMissile()
    {
        transform.position = triggerChecker.TriggeredMissile.FrontPosition;
    }

    public Vector2 CenterPosition => transform.localPosition + Vector3.up * 0.5f;
}
