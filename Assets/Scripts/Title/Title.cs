using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField]
    GameObject title;

    bool isInGameMovable = false;

    // Start is called before the first frame update
    async void Start()
    {
#if UNITY_WEBGL
        Screen.SetResolution(1600, 900, true);
#else
        Screen.SetResolution(1920, 1080, true);
#endif

        isInGameMovable = false;
        await title.transform
            .DOLocalMoveY(-320f, 1f)
            .SetEase(Ease.OutBounce).AsyncWaitForCompletion();

        isInGameMovable = true;
        await title.transform
                    .DOLocalMoveY(-300f, 0.5f)
                    .SetLoops(-1, LoopType.Yoyo).AsyncWaitForCompletion();
    }

    private void Update()
    {
        if (isInGameMovable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DOTween.KillAll();
                SceneManager.LoadScene("InGame");
            }
        }
    }
}
