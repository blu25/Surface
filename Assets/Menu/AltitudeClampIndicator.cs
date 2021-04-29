using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeClampIndicator : MonoBehaviour
{
    public ShipInput player;
    float flashTime = 0f;
    Image clamp;

    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        setPos();
        clamp = GetComponent<Image>();
        lastPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        setPos();

        if (lastPos != transform.localPosition) {
            flashTime = 0.6f;
        }
        if (flashTime > 0f) {
            clamp.color = Color.black;
        } else {
            clamp.color = Color.white;
        }

        flashTime -= Time.deltaTime;
        lastPos = transform.localPosition;
    }

    float map(float s, float a1, float a2, float b1, float b2) {
        return Mathf.Clamp(b1 + (s - a1) * (b2 - b1) / (a2 - a1), b1, b2);
    }

    void setPos() {
        float val = map(player.getBuoyancy(), 1500, 2000, -120, 120);
        transform.localPosition = new Vector3(295, val, 0);
    }
}
