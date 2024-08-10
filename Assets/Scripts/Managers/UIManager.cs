using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField]
    TextMeshProUGUI gameTimeText;

    [SerializeField]
    TextMeshProUGUI triggeredCountText;


    private void Awake()
    {
        instance = this;
    }

    public void SetGameTimeUI(float gameTime)
    {
        gameTimeText.text = $"{gameTime:0.0}";
    }

    public void SetTriggeredCount(int triggeredCount)
    {
        triggeredCountText.text = triggeredCount.ToString();
    }


}
