using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource killMonster;
    [SerializeField] private AudioSource death;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource finishSound;

    public void playDeath()
    {
        death.Play();
    }
    public void playJump()
    {
        jumpSound.Play();
    }
    public void playCollect()
    {
        collectSound.Play();
    }
    public void playkill()
    {
        killMonster.Play();
    }
    public void playfinish()
    {
        finishSound.Play();
    }
}
