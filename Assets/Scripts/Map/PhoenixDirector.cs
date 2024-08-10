using UnityEngine;

public class PhoenixDirector : MonoBehaviour
{
    [SerializeField]
    Phoenix phoenix_1;

    [SerializeField]
    Phoenix phoenix_2;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GameTime > 2f && !phoenix_1.Moved)
        {
            phoenix_1.Move();
        }

        if (GameManager.Instance.GameTime > 7f && !phoenix_2.Moved)
        {
            phoenix_2.Move();
        }
    }
}
