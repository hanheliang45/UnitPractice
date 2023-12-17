using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdExplosion : MonoBehaviour
{
    [SerializeField] Bird bird;

    // Start is called before the first frame update
    void Start()
    {
        bird.Onkill += Bird_Onkill;    
    }

    private void Bird_Onkill(object sender, System.EventArgs e)
    {
        GetComponent<ParticleSystem>().Play();
        this.transform.position = bird.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
