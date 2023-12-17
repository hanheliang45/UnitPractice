using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] Bird bird;
    [SerializeField] GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        bird.Onkill += Bird_Onkill;
    }

    private void Bird_Onkill(object sender, System.EventArgs e)
    {
        button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
