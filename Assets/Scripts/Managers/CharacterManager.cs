using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CharacterManager : MonoBehaviour
{
    static CharacterManager instance;
    public static CharacterManager Instance => instance;

    [SerializeField]
    Transform[] jumperPositions;
    List<CharacterBase> jumpers;

    public int JumperCount => jumpers.Count;

    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private float jumpInterval = 0.5f;

    bool isJumping = false;

    const float APPEARING_DELAY = 0.5f;

    public int AliveCount => jumpers.Count(jumper => jumper.IsAlive);

    private void Awake()
    {
        instance = this;
        jumpers = new List<CharacterBase>();
    }

    public async void Jump()
    {
        var currentJumpers = new List<IJumper>(jumpers);
        foreach (var jumper in currentJumpers)
        {
            jumper.Jump(jumpForce);
            await UniTask.Delay((int)(jumpInterval * 1000));
        }
    }

    public bool IsJumperFull()
    {
        return jumpers.Count >= jumperPositions.Length;
    }

    public async void AddJumper(CharacterBase jumper)
    {
        //Jumper를 추가할수 있는 자리가 있는지 확인
        if (IsJumperFull())
        {
            Debug.LogError("Jumper를 추가할수 있는 자리가 없습니다.");
            return;
        }

        jumper.transform.SetParent(jumperPositions[0], false);
        jumper.Appear();

        //잠시 기다림
        await UniTask.Delay((int)(APPEARING_DELAY * 1000));

        //jumper들을 한칸씩 뒤로 밀어준다.
        for (int i = 0; i < jumpers.Count; i++)
        {
            Transform jt = jumpers[i].transform;
            jt.SetParent(jumperPositions[jumpers.Count - i], false);
        }
        jumpers.Add(jumper);
    }

    public void TakeHot6(Hot6 hot6)
    {
        for (int i = 0; i < jumpers.Count; i++)
        {
            if (jumpers[i].State == CharacterBase.States.Running)
                hot6.Take(i, jumpers[i]);
        }
    }
}
