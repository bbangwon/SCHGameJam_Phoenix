using DarkTonic.MasterAudio;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;

    [SerializeField]
    Transform frontTransform;

    public Vector2 FrontPosition => frontTransform.position;

    private void Start()
    {
        MasterAudio.PlaySound("Missile");
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector3.left * speed * Time.deltaTime);       

        if(GameManager.Instance.Player.State != CharacterBase.States.Die)
        { 
            Vector3 localPosition = transform.localPosition;
            localPosition.y = GameManager.Instance.Player.CenterPosition.y;
            transform.localPosition = localPosition;        
        }
    }
}
