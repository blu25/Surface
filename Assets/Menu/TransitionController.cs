using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    string levelToGoTo;

    float fadeAmount = 1f;
    bool fadingIn = true;

    Image i;

    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public bool winScene = false;

    // Start is called before the first frame update
    void Start()
    {
        i = GetComponent<Image>();

        if (winScene) {
            Invoke("startMainMenuTransition", 6f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn) {
            if (fadeAmount > 0f) {
                fadeAmount -= Time.deltaTime;
            }
        } else {
            if (fadeAmount < 1f) {
                fadeAmount += Time.deltaTime;
            } else {
                doTransition();
            }
        }

        i.color = new Color(255, 255, 255, curve.Evaluate(fadeAmount));
    }

    public void startTransition(string level) {
        levelToGoTo = level;
        fadingIn = false;
    }

    public void startGameTransition() {
        if (PlayerPrefs.GetInt("SeenTutorial") == 1) {
            levelToGoTo = "MainScene";
        } else {
            levelToGoTo = "TutorialSceneFirst";
        }
        fadingIn = false;
    }

    public void startMainMenuTransition() {
        Time.timeScale = 1f;
        fadingIn = false;
        levelToGoTo = "TitleScene";
    }

    void doTransition() {
        SceneManager.LoadScene(levelToGoTo, LoadSceneMode.Single);
    }

    public void quitGame() {
        Application.Quit();
    }

    public bool inTransitionOut() {
        return !fadingIn;
    }
}
