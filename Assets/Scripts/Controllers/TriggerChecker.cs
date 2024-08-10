using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    const string OBSTACLE_TAG = "Obstacle";
    const string MISSILE_TAG = "Missile";

    public bool IsObstacleTriggered => ObstacleTriggeredCount > 0;

    public int ObstacleTriggeredCount { get; private set; } = 0;

    Missile triggeredMissile = null;
    public Missile TriggeredMissile => triggeredMissile;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(OBSTACLE_TAG))
        {
            ObstacleTriggeredCount += 1;
        }

        if(collision.gameObject.tag == MISSILE_TAG)
        {
            triggeredMissile = collision.GetComponent<Missile>();
        }
    }
}
