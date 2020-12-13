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
    private float spawnRate => Random.Range(1f, 2f);

    // Start is called before the first frame update
    void Start()
    {
        isGameAlive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore();
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

    private IEnumerator SpawnTarget()
    {
        while (isGameAlive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }        
    }
}
