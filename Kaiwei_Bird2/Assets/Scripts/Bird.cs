using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using static UnityEngine.Rendering.DebugUI;

public class Bird : MonoBehaviour
{
    public event EventHandler<int> OnScore;
    public event EventHandler Onkill;
    bool isAlive = true;
    bool hasShield = false;
    int score = 0;
    Rigidbody2D body;
    [SerializeField] float jumpHeight;
    [SerializeField] float flySpeed;
    [SerializeField] TextMeshProUGUI scoretext ;
    [SerializeField] int shieldRechargeSpeed;
    [SerializeField] GameObject sheild;
    //[SerializeField] GameObject FlameEffect;
    [SerializeField] VisualEffect flameVisualEffect;
    //[SerializeField] GameObject restart;
    //[SerializeField] ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        flameVisualEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                Reset();
            }
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            body.velocity = Vector2.up * jumpHeight;
            SoundManager.instance.Jump();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.transform.position += new Vector3(Time.deltaTime*flySpeed,0,0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //FlameEffect.SetActive(true);
            flameVisualEffect.Play();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) 
        {
            //FlameEffect.SetActive(false);
            flameVisualEffect.Stop();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.transform.position += new Vector3(Time.deltaTime * -flySpeed, 0, 0);
        }
        if (score >= shieldRechargeSpeed && score% shieldRechargeSpeed == 0) 
        {
            sheild.SetActive(true);
            hasShield = true;
        } 
    }
    public void addScore() 
    { 
        score++;
        //scoretext.text = score.ToString();
        SoundManager.instance.Success();
        OnScore?.Invoke(this,score);
    }
    public void killMe() 
    {
        if (hasShield == true)
        {
            hasShield = false;
            sheild.SetActive (false);
            //GetComponent<CircleCollider2D>().isTrigger = true;
            return;
        }
        //1 isAlive
        isAlive = false;

        //2. destroy bird
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        Onkill?.Invoke(this, null);

        ////3. show explosion particle.
        //explosion.Play();
        //explosion.transform.position = this.transform.position;

        ////4. Restart button
        //restart.SetActive(true);

        ////5. soundManager
        SoundManager.instance.Fail();
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public int getScore()
    {
        return score;    
    }
    public bool IsAlive() 
    {
        return isAlive;
    }



}
