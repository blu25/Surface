using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;

    public float patrolSpeed;
    public float seekSpeed;
    public float scatterSpeed;
    public float patrolTurnSpeed;
    public float turnSpeed;

    public float aggroRadius;
    public float aggroHeight;

    public float scatterRadius;
    public float seekRadius;

    float curSpeed;
    float deathCountdown = 10f;

    bool patrolLeft = false;

    int mode = 0; // 0=patrol, 1=seek/shoot, 2=scatter

    turretController tc;
    Health h;

    public GameObject explosion;
    public GameObject shipRender;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship").transform;
        if (Random.Range(0f, 1f) > 0.5f) {
            patrolLeft = true;
        }

        tc = GetComponentInChildren<turretController>();
        h = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {
        if (h.isAlive()) {
            float speedToUse = 0f;
            switch (mode) {
                case 0: // Patrol
                    if (Vector3.Distance(transform.position, player.position) < aggroRadius &&
                        Mathf.Abs(player.position.y - transform.position.y) < aggroHeight) {
                        mode = 1;
                        tc.setFiring(true);
                    }
                    if (h.getHealthPercent() < 1) {
                        mode = 1;
                    }
                    if (patrolLeft) {
                        transform.Rotate(Vector3.up * Time.deltaTime * patrolTurnSpeed);
                    } else {
                        transform.Rotate(Vector3.down * Time.deltaTime * patrolTurnSpeed);
                    }
                    speedToUse = patrolSpeed;
                    break;
                case 1: // Seek and Shoot
                    if (Vector3.Distance(transform.position, player.position) < scatterRadius) {
                        mode = 2;
                        tc.setFiring(false);
                    }
                    speedToUse = seekSpeed;
                    Quaternion toRotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
                    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * turnSpeed);
                    break;
                case 2: // Scatter and regroup
                    if (Vector3.Distance(transform.position, player.position) > seekRadius) {
                        mode = 1;
                        tc.setFiring(true);
                    }
                    speedToUse = scatterSpeed;
                    break;
            }

            curSpeed = Mathf.Lerp(speedToUse, patrolSpeed, Time.deltaTime * 5f);

            transform.Translate(Vector3.forward * speedToUse * Time.deltaTime);
        } else {
            if (deathCountdown >= 10f) {
                tc.setFiring(false);
                Instantiate(explosion, transform.position, transform.rotation);
                GetComponent<BoxCollider>().enabled = false;
                GetComponentInChildren<Renderer>().enabled = false;
            }
            deathCountdown -= Time.deltaTime;
            if (deathCountdown <= 0f) {
                Destroy(gameObject);
            }
        }
    }

    public bool inCombat() {
        return mode != 0 && h.isAlive();
    }
}
