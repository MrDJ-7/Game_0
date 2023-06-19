// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }
    // слежка камери за игроком
    private void Update()
    {
        pos = player.position;
        pos.z = -10f;
        pos.y += 2f;
        // плавное слежение Lerp
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
