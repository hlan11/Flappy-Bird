using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Vector3 direction;
    [SerializeField] private float gravity;
    [SerializeField] private float strength;
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
}
