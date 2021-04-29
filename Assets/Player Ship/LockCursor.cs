using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene") {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainScene") {
            Cursor.lockState = CursorLockMode.None;
        } else {
            // Lock the cursor on mouse click
            //if (Input.GetMouseButtonDown(0)) {
            //    Cursor.lockState = CursorLockMode.Locked;
            //}

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
        }
    }

    public void lockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
