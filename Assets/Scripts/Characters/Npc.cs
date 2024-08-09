using UnityEngine;

public class Npc : MonoBehaviour, IJumper
{
    JumpController jumpController;

    private void Awake()
    {
        jumpController = GetComponent<JumpController>();
    }

    public void Jump()
    {
        jumpController.Jump();
    }
}
