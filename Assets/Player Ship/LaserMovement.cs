using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed;
    public float lifetime;

    bool alive = true;
    public bool fromPlayer;

    public GameObject explosion;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            lifetime -= Time.deltaTime;

            if (lifetime < 0) {
                die(false);
            }

            checkHit();

            lastPosition = transform.position;
        }
    }

    void checkHit() {
        RaycastHit hit;
        if (Physics.Linecast(lastPosition, transform.position, out hit)) {
            Health ch = hit.transform.gameObject.GetComponent<Health>();
            if (ch != null) {
                ch.hit();
                die(true);

                if (fromPlayer) {
                    RockHandler rh = hit.transform.gameObject.GetComponent<RockHandler>();
                    if (rh) {
                        rh.doReward();
                    }
                }
            }
        }
    }

    void die(bool explode) {
        alive = false;
        Invoke("delete", 1f);

        if (explode)
            Instantiate(explosion, transform.position, transform.rotation);
    }

    void delete() {
        Destroy(gameObject);
    }
}
