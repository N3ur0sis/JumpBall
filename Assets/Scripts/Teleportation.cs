using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
    public ParticleSystem target;
    private ParticleSystem entry;
    public CameraShake shake;
    public Animator flash;
    public PlayerController player;
    bool isTP = false;

    private void Start()
    {
        entry = GetComponent<ParticleSystem>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        shake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
        flash = GameObject.Find("FlashScreen").GetComponent<Animator>();
    }
    private void Update()
    {
        if (!target.isEmitting && target.loop == true)
        {
            target.Play();
        }
        if (isTP && target.isEmitting && entry.isEmitting)
        {
            target.Play();
            entry.Play();
            target.loop = false;
            entry.loop = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = target.gameObject.transform.position;

        flash.SetBool("tp", true);
        StartCoroutine(shake.Shake(0.4f, 0.08f));
        player.Teleport();
        isTP = true;
    }

    private void Reset()
    {
        flash.SetBool("tp", false);
    }
}
