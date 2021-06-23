using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 20f)] [SerializeField] float gameSpeed = 1f;
    int pointsPerBlock = 80;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled = false;

    [SerializeField] int currentScore = 0;
    // Level level;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // level = FindObjectOfType<Level>();
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        // currentScore = level.getBrokenBlocks() * pointsPerBlock;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void DestroyStatus()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
