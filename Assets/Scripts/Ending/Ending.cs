using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] 
    Sprite[] _endingSprite;

    [SerializeField]
    Image endingImage;

    private void Start()
    {
        if(endingImage != null && _endingSprite != null)
        {
            endingImage.sprite = _endingSprite[Random.Range(0, _endingSprite.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
