using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    

    [SerializeField] private AudioSource success;
    [SerializeField] private AudioSource fail;
    [SerializeField] private AudioSource jump;


    private void Awake()
    {
        instance = this;
    }

    public void Success() 
    {
        success.Play();
    }
    public void Fail() { fail.Play(); }

    public void Jump() { jump.Play(); }












}

