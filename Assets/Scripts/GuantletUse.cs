using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuantletUse : MonoBehaviour
{
    public TimeFlip PlayerTravelled;
    private bool travelled;
    private bool mybool = true;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTravelled == mybool)
        {
            anim.SetBool("use", true);
            mybool = !PlayerTravelled;
        }
    }
}
