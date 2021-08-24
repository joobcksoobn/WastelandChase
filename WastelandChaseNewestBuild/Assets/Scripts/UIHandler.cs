using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject[] pauseObjects;
    [SerializeField] GameObject[] FinishObjects;
    [SerializeField] GameObject PauseButton;
    public Transform player;
    public HealthHandler playerHealth;
    public string CurrScene;
    // Start is called before the first frame update
    void Start()
    {
        CurrScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        if (CurrScene == "roadScene")
        {
            player = GameObject.FindWithTag("Player").transform;
            playerHealth = player.GetComponent<HealthHandler>();
            HidePaused();
            HideFinished();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrScene == "roadScene" && playerHealth.Alive == false && Time.timeScale == 0)
        {
            ShowFinished();
        }
    }

    //  Reload level
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //  Pause game and show objects with ShowOnPauseTag
    public void pauseControl()
    {
        if(Time.timeScale == 1)
        {
            
            Time.timeScale = 0;
            ShowPaused();
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    public void ShowPaused()
    {
        
        if(pauseObjects.Length == 0)
        {
            Debug.Log("length = 0");
            pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
            Debug.Log(pauseObjects.Length);
        }
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
        PauseButton.SetActive(false);
    }

    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        PauseButton.SetActive(true);
    }

    public void ShowFinished()
    {
        foreach (GameObject g in FinishObjects)
        {
            g.SetActive(true);
        }
        PauseButton.SetActive(false);
    }

    public void HideFinished()
    {
        foreach (GameObject g in FinishObjects)
        {
            g.SetActive(false);
        }
        PauseButton.SetActive(true);
    }

    public void LoadLevel( string level)
    {
        SceneManager.LoadScene(level);
    }
}
