using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSet : MonoBehaviour
{
    [SerializeField] Hero hero;
    [SerializeField] float pipeSpeed;
    private 
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
}
