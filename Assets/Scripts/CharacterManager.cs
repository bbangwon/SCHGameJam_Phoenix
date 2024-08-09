using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    static CharacterManager instance;
    public static CharacterManager Instance => instance;

    [SerializeField]
    Transform[] jumperPositions;
    List<IJumper> jumpers;

    [SerializeField]
    private float jumpInterval = 0.5f;

    bool isJumping = false;

    private void Awake()
    {
        instance = this;
        jumpers = new List<IJumper>();
    }

    public async void Jump()
    {
        var currentJumpers = new List<IJumper>(jumpers);
        foreach (var jumper in currentJumpers)
        {
            jumper.Jump();
            await UniTask.Delay((int)(jumpInterval * 1000));
        }
    }

    public bool IsJumperFull()
    {
        return jumpers.Count >= jumperPositions.Length;
    }

    public void AddJumper(IJumper jumper)
    {
        //Jumper를 추가할수 있는 자리가 있는지 확인
        if (IsJumperFull())
        {
            Debug.LogError("Jumper를 추가할수 있는 자리가 없습니다.");
            return;
        }

        //jumper들을 한칸씩 뒤로 밀어준다.
        for (int i = 0; i < jumpers.Count; i++)
        {
            Transform jt = (jumpers[i] as MonoBehaviour).transform;
            jt.SetParent(jumperPositions[jumpers.Count - i], false);
        }

        Transform jumperTransform = (jumper as MonoBehaviour).transform;

        jumperTransform.SetParent(jumperPositions[0], false);
        jumpers.Add(jumper);
    }
}
