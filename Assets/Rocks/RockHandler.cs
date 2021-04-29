using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHandler : MonoBehaviour
{
    Health h;
    public GameObject explosion;
    public GameObject rockCollect;
    public float rotationVelocity;

    Vector3 rotationDirection;
    float rotationSpeed;

    bool reward = false;

    ShipInput si;

    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<Health>();

        rotationDirection = new Vector3(Random.Range(-rotationVelocity, rotationVelocity),
                                        Random.Range(-rotationVelocity, rotationVelocity),
                                        Random.Range(-rotationVelocity, rotationVelocity));

        GameObject ps = GameObject.Find("Player Ship");
        if (ps) {
            si = GameObject.Find("Player Ship").GetComponent<ShipInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection * Time.deltaTime);
        if (!h.isAlive()) {
            Instantiate(explosion, transform.position, transform.rotation);
            if (reward) {
                si.changeBuoyancy(10f);
                Instantiate(rockCollect, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    // If crashed into by player, don't reward with buoyancy
    public void doReward() {
        reward = true;
    }
}
