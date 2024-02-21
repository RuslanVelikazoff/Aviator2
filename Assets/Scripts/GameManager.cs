using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    private Player player;
    private LevelUIManager levelUI;

    private void Start()
    {
        levelUI = FindObjectOfType<LevelUIManager>();
        player = FindObjectOfType<Player>();
    }

    public void AddScore()
    {
        score++;
        levelUI.SetScoreText();
    }

    public void DamagePlayer(GameObject enemy)
    {
        Destroy(enemy);
        player.Health--;
        levelUI.SetHealthBar();

        if (player.Health <= 0)
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        Time.timeScale = 0;

        if (score > PlayerPrefs.GetInt(Constants.DATA.HIGH_SCORE))
        {
            //Open new record panel
        }
        else
        {
            //Open standart panel
        }
    }
}
