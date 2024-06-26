using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Vector3 direction;
    [SerializeField] private float gravity;
    [SerializeField] private float strength;
    
    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Start()
    {
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up*strength;
        }
        direction.y +=gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if (collision.CompareTag("score"))
        {
            FindObjectOfType<GameManager>().increaseScore();
        }
    }
    
}
