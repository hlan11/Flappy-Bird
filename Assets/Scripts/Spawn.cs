using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject pipePrefarb;
    [SerializeField] private float spawnRate;
    [SerializeField] private float minHeight;
    [SerializeField]private float maxHeight;
    private void OnEnable()
    {
        InvokeRepeating(nameof(pipeSpawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(pipeSpawn));
    }
    void pipeSpawn()
    {
        GameObject pipes = Instantiate(pipePrefarb, transform.position, Quaternion.identity); //command (using System.Numerics;)
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
