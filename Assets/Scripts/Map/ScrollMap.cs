using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 1.0f;

    private void Update()
    {
        if(GameManager.Instance.IsGameing)
        {
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        }
    }

    public void Scroll()
    {
        
    }
}
