using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
        LifeManager.instance.OnLose += Game_OnLose;    
    }

    private void Game_OnLose(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(true);
    }

    public void Restart() 
    {
        Debug.Log("Reloading");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
