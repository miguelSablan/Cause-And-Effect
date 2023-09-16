using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndDoor : MonoBehaviour
{
    [SerializeField] private GameObject waypoint;

    [SerializeField] private float speed = 150f;

    private int i = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (i > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
            i = 0;
        }
        
    }

}
