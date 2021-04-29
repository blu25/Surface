using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollectAnimation : MonoBehaviour
{
    Transform player;
    Vector3 startpos;

    float travelTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Ship").transform;
        transform.rotation = Quaternion.Euler(Random.Range(0, 360),
                                              Random.Range(0, 360),
                                              Random.Range(0, 360));
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startpos, player.position, travelTime);
        transform.Rotate(Time.deltaTime * 90f, Time.deltaTime * 45f, 0);

        travelTime += Time.deltaTime;

        if (travelTime > 1f) {
            Destroy(gameObject);
        }
    }
}
