using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    Health playerHealth;
    public Vector3 distanceFromPlayer;
    public Vector3 distanceToLookFromPlayer;
    public float cameraSpeed;

    float hitRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookBehindPos = player.rotation * distanceFromPlayer;
        transform.position = Vector3.Lerp(
            transform.position,
            player.position + lookBehindPos,
            Time.deltaTime * cameraSpeed
        );

        if (playerHealth.justHit()) {
            hitRotation = 20f;
        }
        hitRotation *= 0.9f;


        Vector3 lookAtPos = player.position + (player.rotation * distanceToLookFromPlayer);
        transform.LookAt(lookAtPos);

        // Handle camera shaking when player is hit
        transform.Rotate(new Vector3(0, 0, hitRotation));
    }
}
