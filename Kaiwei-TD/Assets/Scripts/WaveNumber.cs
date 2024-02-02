using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveNumber : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    void Start()
    {
        enemySpawner.OnNewWave += EnemySpawner_OnNewWave;      
    }

    private void EnemySpawner_OnNewWave(object sender, int e)
    {
        this.GetComponent<TextMeshProUGUI>().text = e.ToString();
    }
}
