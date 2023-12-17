using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Bird bird;
    // Start is called before the first frame update
    void Start()
    {
        bird.OnScore += Bird_OnScore;    
    }

    private void Bird_OnScore(object sender, int e)
    {
        GetComponent<TextMeshProUGUI>().text = e.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
