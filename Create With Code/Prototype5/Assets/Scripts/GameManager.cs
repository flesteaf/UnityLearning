using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameAlive;
    private int score;
    private GameObject titleScreen;
    private float spawnRate => Random.Range(1f, 2f);

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("TitleScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameAlive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd = 0)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void StartGame(int difficulty)
    {
        isGameAlive = true;
        StartCoroutine(SpawnTarget(spawnRate/difficulty));
        score = 0;
        UpdateScore();
        titleScreen.SetActive(false);
    }

    private IEnumerator SpawnTarget(float spawnRate)
    {
        while (isGameAlive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }        
    }
}
