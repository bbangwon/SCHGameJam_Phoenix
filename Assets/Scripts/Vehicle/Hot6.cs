using DG.Tweening;
using UnityEngine;

public class Hot6 : MonoBehaviour
{
    [SerializeField]
    private Transform[] positionTransforms;

    Vector3[] waypoints = new[] { 
        new Vector3(-4.940734f, -1.131354f, 0f), 
        new Vector3(3.585045f, 0.3976327f, 0f), 
        new Vector3(12.79033f, 4.612154f, 0f) 
    };

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Go();
        }
    }

    public void Go()
    {
       transform.DOPath(waypoints, 3f, PathType.CatmullRom, PathMode.Sidescroller2D, 10, Color.red)
            .OnWaypointChange(OnWaypointChange)
            .OnComplete(OnComplete);
    }

    private void OnWaypointChange(int index)
    {
        Debug.Log($"OnWaypointChange {index}");
        if(index == 1)
        {
            //캐릭터들을 모두 태운다.
            CharacterManager.Instance.TakeHot6(this);
        }
    }

    private void OnComplete()
    {
        //도착했을때..
    }

    public void Take(int index, CharacterBase character)
    {
        Debug.Log($"Take {index} {character.name}");

        if (character.State != CharacterBase.States.Running)
            return;

        character.transform.SetParent(positionTransforms[index], false);
        character.transform.localPosition = Vector3.zero;
        character.TakeHot6();
    }
}
