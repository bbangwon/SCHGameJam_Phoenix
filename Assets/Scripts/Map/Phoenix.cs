using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : MonoBehaviour
{
    [SerializeField]
    float goalY;

    bool moved = false;

    public bool Moved => moved;   

    public void Move()
    {
        if (moved)
            return;

        moved = true;

        transform.DOMoveY(goalY, 3f);
    }
}
