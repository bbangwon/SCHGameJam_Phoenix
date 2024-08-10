using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance => instance;

    const float TOTAL_GAME_TIME = 11f;

    [SerializeField]
    CharacterBase[] jumpablePrefab; //0번은 플레이어, 나머지는 순서대로

    [SerializeField]
    float npcSpawnTime = 2f;

    float gameTime = 0f;
    float npcSpawnTimer = 0f;

    [SerializeField]
    Missile missilePrefab;

    [SerializeField]
    Hot6 hot6;

    const float MissileSpawnPositionX = 11f;

    Player player;
    public Player Player => player;


    public bool IsGameing => State == GameStates.Start;

    public enum GameStates
    {
        Ready,
        Start,
        Over
    }

    public GameStates State { get; private set; } = GameStates.Ready;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        if(State == GameStates.Start)
        {
            ProcessGameTime();
            ProcessNpcSpawn();
        }
    }

    void ProcessGameTime()
    {
        gameTime += Time.deltaTime;
        UIManager.Instance.SetGameTimeUI(gameTime);

        if(gameTime >= TOTAL_GAME_TIME)
        {
            Debug.Log($"{TOTAL_GAME_TIME}초 지남 게임 끝!");
            State = GameStates.Over;

            hot6.Go();
        }
    }

    void ProcessNpcSpawn()
    {
        if (CharacterManager.Instance.IsJumperFull())
            return;

        npcSpawnTimer += Time.deltaTime;

        if (npcSpawnTimer >= npcSpawnTime)
        {
            npcSpawnTimer = 0f;
            AddJumper();
        }
    }

    void GameStart()
    {
        //Player 생성
        player = Instantiate(jumpablePrefab[0], new Vector3(0, 0, 0), Quaternion.identity) as Player;
        CharacterManager.Instance.AddJumper(player);

        State = GameStates.Start;
    }    

    void AddJumper()
    {
        if (CharacterManager.Instance.IsJumperFull())
        {
            Debug.LogError("Jumper가 꽉 찼습니다.");
            return;
        }

        CharacterBase npc = Instantiate(jumpablePrefab[CharacterManager.Instance.JumperCount], new Vector3(0, 0, 0), Quaternion.identity);
        CharacterManager.Instance.AddJumper(npc);
    }

    public void LaunchMissile()
    {
        Missile missile = Instantiate(missilePrefab, new Vector3(MissileSpawnPositionX, player.transform.localPosition.y, 0), Quaternion.identity);

    }
}
