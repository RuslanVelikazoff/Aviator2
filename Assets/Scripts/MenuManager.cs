using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Text highScoreText;

    private void Awake()
    {
        SetHighScoreText();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }
    }

    private void SetHighScoreText()
    {
        if (!PlayerPrefs.HasKey(Constants.DATA.HIGH_SCORE))
        {
            highScoreText.text = "";
        }
        else
        {
            highScoreText.text = $"Ваш рекорд: \n{PlayerPrefs.GetInt(Constants.DATA.HIGH_SCORE)}";
        }
    }
}
