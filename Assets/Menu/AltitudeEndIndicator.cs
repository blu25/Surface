using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeEndIndicator : MonoBehaviour
{
    public ShipInput player;

    float alertTime = 0f;
    Image altImg;

    // Start is called before the first frame update
    void Start()
    {
        altImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.getBuoyancy() <= 1500f) {
            alertTime += Time.deltaTime * 2f;
        } else {
            alertTime = 0f;
        }
        if (alertTime % 2f >= 1) {
            altImg.color = Color.green;
        } else {
            altImg.color = Color.white;
        }
    }
}
