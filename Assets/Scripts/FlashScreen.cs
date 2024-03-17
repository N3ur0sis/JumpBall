using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScreen : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Reset()
    {
        anim.SetBool("tp", false);
    }
}
