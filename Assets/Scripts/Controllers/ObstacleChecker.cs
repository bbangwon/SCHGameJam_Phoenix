using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    const string OBSTACLE_TAG = "Obstacle";

    public bool IsTriggered => TriggeredCount > 0;

    public int TriggeredCount { get; private set; } = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(OBSTACLE_TAG))
        {
            TriggeredCount += 1;
        }
    }
}
