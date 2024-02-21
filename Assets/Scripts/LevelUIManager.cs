using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private Button pauseButton;

    [SerializeField]
    private GameObject[] healthPoint;

    [SerializeField]
    private Text scoreText;

    private Player player;
    private GameManager gameManager;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();

        ButtonClickAction();
        SetHealthBar();
        SetScoreText();
    }

    private void ButtonClickAction()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    public void SetHealthBar()
    {
        for (int i = 0; i < healthPoint.Length; i++)
        {
            if (i < player.Health)
            {
                healthPoint[i].SetActive(true);
            }
            else
            {
                healthPoint[i].SetActive(false);
            }
        }
    }

    public void SetScoreText()
    {
        scoreText.text = gameManager.score.ToString();
    }
}
