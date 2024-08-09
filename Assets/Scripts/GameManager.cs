using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject npcPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if(CharacterManager.Instance.IsJumperFull())
            {
                Debug.LogError("Jumper�� �� á���ϴ�.");
                return;
            }

            GameObject npcObject = Instantiate(npcPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            CharacterManager.Instance.AddJumper(npcObject.GetComponent<IJumper>());
        }
    }
}
