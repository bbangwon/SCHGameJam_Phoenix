using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector3.left * speed * Time.deltaTime);       

        Vector3 localPosition = transform.localPosition;
        localPosition.y = GameManager.Instance.Player.CenterPosition.y;
        transform.localPosition = localPosition;
        
    }
}
