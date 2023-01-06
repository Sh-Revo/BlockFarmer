using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameStat gameStat;
    public enum GameStat
    {
        Start,
        Play,
        Failed
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        gameStat = GameStat.Start;
        Time.timeScale = 0;
    }

    public void SetGamePlayStat()
    {
        gameStat = GameStat.Play;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
