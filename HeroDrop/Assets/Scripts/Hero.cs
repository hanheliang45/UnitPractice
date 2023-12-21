using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero instance;
    private void Awake()
    {
        instance = this;
    }
    public event EventHandler OnKill;
    [SerializeField] float heroSpeed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 4.83 || this.transform.position.y < -4.83)
        {
            
            OnKill?.Invoke(this, null);
            animator.SetBool("IsAlive",false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(Time.deltaTime * heroSpeed, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(Time.deltaTime * -heroSpeed, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
