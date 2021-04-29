using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxUpdater : MonoBehaviour
{
    Material sb;
    // Start is called before the first frame update
    void Start()
    {
        sb = RenderSettings.skybox;
        sb.SetFloat("_AtmosphereThickness", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        float heightAboveGround = transform.position.y;
        float colorValue = map(heightAboveGround, 2000f, 1500f, 0.25f, .7f);
        colorValue = Mathf.Clamp(colorValue, 0f, .7f);
        
        sb.SetFloat("_AtmosphereThickness", colorValue);
    }

    float map(float s, float a1, float a2, float b1, float b2) {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
