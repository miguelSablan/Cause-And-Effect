using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TimeDisplacement : MonoBehaviour
{
    public TimeFlip PlayerTravelled;
    private bool travelled;
    private bool mybool;

    [SerializeField] private bool inPresent;
    [SerializeField] private bool inFuture;
    [SerializeField] private bool hasCollision;

    TilemapRenderer tilemap;
    TilemapCollider2D collision;

    void Start()
    {
        tilemap = GetComponent<TilemapRenderer>();
        collision = GetComponent<TilemapCollider2D>();

        travelled = PlayerTravelled.useTimeTravel;
        mybool = true;
        DisplaceCollision(inFuture, inPresent, travelled);
    }

    // Update is called once per frame
    void Update()
    {
        travelled = PlayerTravelled.useTimeTravel;
        if (travelled == mybool)
        {

            DisplaceCollision(inFuture, inPresent, travelled);
            ReplaceCollision(inFuture, inPresent, travelled);

            mybool = !travelled;
        }
    }

    private void DisplaceCollision(bool inFuture, bool inPresent, bool travelled)
    {
        if (inFuture && !inPresent && !travelled)
        {
            tilemap.enabled = false;
            if(hasCollision)
            {
                collision.enabled = false;
            }
        }
        else if (!inFuture && inPresent && travelled)
        {
            tilemap.enabled = false;
            if (hasCollision)
            {
                collision.enabled = false;
            }
        }
    }

    private void ReplaceCollision(bool inFuture, bool inPresent, bool travelled)
    {
        if (inFuture && !inPresent && travelled)
        {
            tilemap.enabled = true;
            if (hasCollision)
            {
                collision.enabled = true;
            }
        }
        else if (!inFuture && inPresent && !travelled)
        {
            tilemap.enabled = true;
            if (hasCollision)
            {
                collision.enabled = true;
            }
        }
    }
}
