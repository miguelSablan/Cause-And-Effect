using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlip : MonoBehaviour
{
    [SerializeField] private float cooldown = 1f;
    private float nextUse = 0f;
    public bool useTimeTravel = false;
    private bool mybool = true;

    //[SerializeField] private AudioSource timeFlipSF;

    void Update()
    {
        if (Time.time > nextUse)
        {
            if (Input.GetButtonDown("Time Flip"))
            {
                // timeFlipSF.Play();

                FutureSwap();
                nextUse = Time.time + cooldown;
            }
        }
        
    }

    private void FutureSwap()
    {
        if (!useTimeTravel)
        {
            useTimeTravel = true;
            print("not in present");
        } else
        {
            useTimeTravel = false;
            print("back in present");

        }
    }
}
