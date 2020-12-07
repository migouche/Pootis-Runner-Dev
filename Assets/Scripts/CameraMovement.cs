using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerMovement player;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 4);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(offset * player.side, transform.position.y, transform.position.z), player.sidespeed * offset / player.offset);
    }
}
