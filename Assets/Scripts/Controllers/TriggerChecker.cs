using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    const string OBSTACLE_TAG = "Obstacle";
    const string MISSILE_TAG = "Missile";
    const string DEADZONE_TAG = "DeadZone";

    public bool IsObstacleTriggered => ObstacleTriggeredCount > 0;
    public int ObstacleTriggeredCount { get; private set; } = 0;

    Missile triggeredMissile = null;
    public Missile TriggeredMissile => triggeredMissile;
    public bool IsDeadZoneTriggered { get; private set; } = false;

    bool isStarted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isStarted)
            return;

        if(collision.gameObject.layer == LayerMask.NameToLayer(OBSTACLE_TAG))
        {
            ObstacleTriggeredCount += 1;
        }

        if(collision.gameObject.tag == MISSILE_TAG)
        {
            triggeredMissile = collision.GetComponent<Missile>();
        }

        if(collision.gameObject.tag == DEADZONE_TAG)
        {
            IsDeadZoneTriggered = true;
        }
    }

    public void StartCheck()
    {
        triggeredMissile = null;
        ObstacleTriggeredCount = 0;
        IsDeadZoneTriggered = false;

        isStarted = true;
    }

    public void StopCheck()
    {
        isStarted = false;
    }
}
