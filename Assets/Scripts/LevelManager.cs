using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager: MonoBehaviour
{
    private Text scoreTxt;
    private Text levelName;
    string currentSceneName;
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        scoreTxt = canvas.transform.Find("Score").GetComponent<Text>();
        levelName = canvas.transform.Find("Level").GetComponent<Text>();
        currentSceneName = SceneManager.GetActiveScene().name;
        levelName.text = currentSceneName;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log(PickUp.getCounter().ToString());
            scoreTxt.text = PickUp.getCounter().ToString();
        }
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log(PickUp.getCounter().ToString());
            scoreTxt.text = PickUp.getCounter().ToString();
        }
    }
}