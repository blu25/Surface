using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    public Health player;

    float alertTime = 0f;
    float flashTime = 0f;
    Image healthImg;

    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        healthImg = GetComponent<Image>();
        lastPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float val = map(player.getHealthPercent(), 0, 1, -120, 120);
        transform.localPosition = new Vector3(-290, val, 0);

        if (lastPos != transform.localPosition) {
            flashTime = 0.6f;
        }

        if (player.getHealth() == 1) {
            alertTime += Time.deltaTime * 2f;
        } else {
            alertTime = 0f;
        }
        if (alertTime % 2f >= 1 || flashTime > 0f) {
            healthImg.color = Color.red;
        } else {
            healthImg.color = Color.white;
        }

        flashTime -= Time.deltaTime;
        lastPos = transform.localPosition;

    }

    float map(float s, float a1, float a2, float b1, float b2) {
        return Mathf.Clamp(b1 + (s - a1) * (b2 - b1) / (a2 - a1), b1, b2);
    }
}
