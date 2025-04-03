using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        resetScore();
        LoadNextScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetScore()
    {
        PickUp.resetCounter();
    }
    public void LoadNextScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the scene with the next index
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
