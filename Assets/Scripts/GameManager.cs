using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    private LevelUIManager levelUI;

    private void Start()
    {
        levelUI = FindObjectOfType<LevelUIManager>();
    }

    public void AddScore()
    {
        score++;
        levelUI.SetScoreText();
    }
}
