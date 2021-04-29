using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    public float fireRate;
    public float accuracy;
    public float viewRange;

    public GameObject laser;

    bool isFiring;
    float curFireCountdown;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (isFiring && Quaternion.Angle(transform.parent.rotation, transform.rotation) < viewRange) {
            curFireCountdown -= Time.deltaTime;

            Quaternion spread = Quaternion.Euler(Random.Range(-accuracy, accuracy),
                                                 Random.Range(-accuracy, accuracy),
                                                 Random.Range(-accuracy, accuracy));

            if (curFireCountdown <= 0) {
                curFireCountdown = fireRate;
                Instantiate(laser, transform.position, spread * transform.rotation);
            }
        }
    }

    public void setFiring(bool val) {
        isFiring = val;
    }
}
