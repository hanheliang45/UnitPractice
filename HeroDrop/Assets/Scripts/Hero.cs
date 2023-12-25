using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    bool IsAlive = true;
    bool canSprint = true;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    public static Hero instance;
    private void Awake()
    {
        instance = this;
    }
    public event EventHandler OnKill;
    [SerializeField] float SprintingSpeed;
    [SerializeField] float heroSpeed;
    private Animator animator;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 4.83 || this.transform.position.y < -4.83)
        {
            
            OnKill?.Invoke(this, null);
            animator.SetBool("IsAlive", false);
            IsAlive = false;
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
        if (Input.GetKeyDown(KeyCode.Space) && canSprint==true && Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity=new Vector3(5, 1, 0).normalized * SprintingSpeed;
            canSprint = false;
        }
        if (Input.GetKey(KeyCode.Space)&& Input.GetKey(KeyCode.LeftArrow)&& canSprint == true) 
        {
            body.velocity = new Vector3(-5, 1, 0).normalized * SprintingSpeed;
            canSprint = false;
        }
        if (Input.anyKeyDown&&IsAlive == false) 
        {
            Hero.instance.Reset();
        }



    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void AddScore() 
    {
        score++;
        scoreText.text = score.ToString();  
    }
    public void Sprinting() 
    {
        canSprint = true;
        body.velocity =new Vector3(0,0,0);
    }
    public void Die() 
    {
        OnKill?.Invoke(this, null);
        animator.SetBool("IsAlive", false);
        IsAlive = false;
    }
   

}
