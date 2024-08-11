using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cysharp.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField]
    TextMeshProUGUI gameTimeText;

    [SerializeField]
    Image gameDescriptionImage;

    private void Awake()
    {
        instance = this;
        gameDescriptionImage.raycastTarget = false;
    }

    private async void Start()
    {
        //�ٷ� Ŭ���� ���� ���� 0.5�� �ڿ� Ȱ��ȭ
        await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
        gameDescriptionImage.raycastTarget = true;
    }

    public void SetGameTimeUI(float gameTime)
    {
        gameTimeText.text = $"{gameTime:0.0}";
    }

    public void OnClickGameDescription()
    {
        if (GameManager.Instance.State == GameManager.GameStates.Ready)
        {
            gameDescriptionImage.gameObject.SetActive(false);
            GameManager.Instance.GameStart();
        }
    }
}
