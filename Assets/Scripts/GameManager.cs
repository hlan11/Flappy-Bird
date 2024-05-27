using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player _player;
    public TextMeshProUGUI scoreText;
    public GameObject _GameOver;
    public GameObject PlayButton;
    private int score;
    private void Awake()
    {
        _player = GetComponent<Player>();
        PauseGame();
    }
    public void PlayGame()
    {
        Application.targetFrameRate = 60;
        scoreText.text=score.ToString();

        PlayButton.SetActive(false);
        _GameOver.SetActive(false);

        Time.timeScale = 1;
        _player.enabled=true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        _player.enabled= false;
    }
    public void increaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        _GameOver.SetActive(true);
        PlayButton.SetActive(true);
        PauseGame();
    }
}
