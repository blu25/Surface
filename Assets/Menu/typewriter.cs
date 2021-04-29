using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewriter : MonoBehaviour
{
    public float delay;
    string val;
    Text t;
    public Button b;
    bool skip = false;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        if (PlayerPrefs.GetInt("SeenTutorial") != 1) {
            val = t.text;
            t.text = "";
            StartCoroutine(typeText());
        }
        PlayerPrefs.SetInt("SeenTutorial", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            skip = true;
        }
    }

    IEnumerator typeText() {
        b.enabled = false;
        for (int i=0; i<=val.Length; i++) {
            string curText = val.Substring(0, i);
            t.text = curText;
            if (skip) {
                t.text = val;
                break;
            }
            yield return new WaitForSeconds(delay);
        }
        b.enabled = true;
    }
}
