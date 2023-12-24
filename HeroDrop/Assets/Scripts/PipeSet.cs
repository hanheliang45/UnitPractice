using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSet : MonoBehaviour
{
    public static PipeSet instance;
    [SerializeField] Hero hero;
    [SerializeField] float pipeSpeed;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hero.instance.OnKill += Instance_OnKill;
        this.transform.position += new Vector3(0,Time.deltaTime*pipeSpeed,0);
        if (this.transform.position.y>15) 
        {
            Destroy(this.gameObject); 
        }
    }

    private void Instance_OnKill(object sender, System.EventArgs e)
    {
        pipeSpeed = -1; 
    }
    public Transform GetPosition() 
    {
        return transform;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Hero hero = collision.gameObject.GetComponent<Hero>();
        hero.Sprinting();
    }
    
}
