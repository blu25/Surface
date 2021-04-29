using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked) {
            pauseScreen.SetActive(false);
            //Time.timeScale = 1;
        } else {
            pauseScreen.SetActive(true);
            //Time.timeScale = 0;
        }
        

    }
}
