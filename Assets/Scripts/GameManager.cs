using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Player _player;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public GameObject PlayButton;
    private int score;
    [SerializeField] private AudioSource scoreMusic;
    
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void PlayGame()
    {
        score = 0;
        scoreText.text=score.ToString();

        PlayButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        _player.enabled=true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
    }
    public void increaseScore()
    {
        scoreMusic.Play();
        score++;
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
       gameOver.SetActive(true);
       PlayButton.SetActive(true);
       Pause();
    }
    
}
