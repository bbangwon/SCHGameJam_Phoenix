using UnityEngine;

public class Player : MonoBehaviour, IJumper
{
    GroundChecker groundChecker;
    JumpController jumpController;

    private void Awake()
    {
        groundChecker = GetComponent<GroundChecker>();
        jumpController = GetComponent<JumpController>();
    }

    private void Start()
    {
        CharacterManager.Instance.AddJumper(this);
    
    }

    public void Jump()
    {
        jumpController.Jump();
    }

    void OnJump()
    {
        if (groundChecker.IsGrounded)
        {
            CharacterManager.Instance.Jump();
        }
    }
}
