using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    public float speed;
    public float inputSensitivity;
    public float rotationSpeed;
    public float rollMultiplier;
    public bool useBuoyancy;

    public TransitionController ts;

    Vector2 shipRotation = Vector3.zero;
    Vector2 curShipRotation = Vector3.zero;
    Health h;
    AudioSource explodeClip;

    public float buoyancyLevel = 1900f;
    // 1500 - 2000

    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<Health>();
        explodeClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (h.isAlive()) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Cursor.lockState == CursorLockMode.Locked) {
                shipRotation += getMouseVector() * inputSensitivity;
                shipRotation = new Vector2(shipRotation.x, Mathf.Clamp(shipRotation.y, -80, 80));
                //float rollAmt = getMouseVector().x * rollMultiplier;


            }
            if (useBuoyancy) {
                if (transform.position.y < buoyancyLevel && shipRotation.y < 0) {
                    shipRotation.y = 0;
                }
            }
            curShipRotation = Vector2.Lerp(curShipRotation, shipRotation, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(-curShipRotation.y, curShipRotation.x, 0);

            if (transform.position.y <= 1500) {
                ts.startTransition("WinScene");
            }
        } else {
            ts.startTransition("TitleScene");
            if (explodeClip.isPlaying == false) {
                explodeClip.Play();
            }
        }
    }

    Vector2 getMouseVector() {
        Vector2 mouseVal = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

#if UNITY_WEBGL
        // Workaround to fix mouse over-sensitivity in webgl version
        mouseVal *= 0.2f;
#endif

        Vector2 keyVal = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 0.2f;
#if UNITY_WEBGL
        // Workaround to fix keyboard under-sensitivity in webgl version
        keyVal *= 1.5f;
#endif
        return mouseVal + keyVal;
    }

    public void changeBuoyancy(float amt) {
        buoyancyLevel -= amt;
    }

    public float getBuoyancy() {
        return buoyancyLevel;
    }

    public void OnCollisionEnter(Collision col) {
        if (col.gameObject.layer == 6) { // Layer 6 is obstacle layer
            Health ch = col.gameObject.GetComponent<Health>();
            if (ch != null) {
                h.hit();
                ch.hit();
            }
        }
    }
}
