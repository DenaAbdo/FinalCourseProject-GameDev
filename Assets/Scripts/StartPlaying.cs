using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartPlaying : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        Button playBtn = GetComponent<Button>();
        PickUp.resetCounter();
        playBtn.onClick.AddListener(OnButtonClick);
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void OnButtonClick()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
