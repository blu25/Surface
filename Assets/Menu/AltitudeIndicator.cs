using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeIndicator : MonoBehaviour
{
    public Transform player;
    ShipInput ship;

    float alertTime = 0f;
    Image altImg;

    // Start is called before the first frame update
    void Start()
    {
        altImg = GetComponent<Image>();
        ship = player.GetComponent<ShipInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float val = map(player.position.y, 1500, 2000, -120, 120);
        transform.localPosition = new Vector3(290, val, 0);

        if (ship.getBuoyancy() >= player.position.y) {
            alertTime += Time.deltaTime * 2f;
        } else {
            alertTime = 0f;
        }
        if (alertTime % 2f >= 1) {
            altImg.color = Color.black;
        } else {
            altImg.color = Color.white;
        }
    }

    float map(float s, float a1, float a2, float b1, float b2) {
        return Mathf.Clamp(b1 + (s - a1) * (b2 - b1) / (a2 - a1), b1, b2);
    }
}
