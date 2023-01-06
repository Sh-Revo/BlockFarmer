using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject _gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (GameManager.Instance.gameStat == GameManager.GameStat.Failed)
        {
            EndGameScreen();
        }
    }

    private void EndGameScreen()
    {
        _gameOverPanel.SetActive(true);
    }
}
