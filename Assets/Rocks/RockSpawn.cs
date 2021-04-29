using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public GameObject rock;
    public int numRocks;

    Bounds boxSize;

    // Start is called before the first frame update
    void Start()
    {
        boxSize = GetComponent<BoxCollider>().bounds;

        for (int i=0; i<numRocks; i++) {
            GameObject cur = Instantiate(rock,
                                         new Vector3(Random.Range(boxSize.min.x, boxSize.max.x),
                                                     Random.Range(boxSize.min.y, boxSize.max.y),
                                                     Random.Range(boxSize.min.z, boxSize.max.z)),
                                         transform.rotation);
            float maxSize = Mathf.Clamp((cur.transform.position.y - 1500) / 50f, 1f, 10f);
            float scaleAmt = Random.Range(1f, maxSize);
            cur.transform.localScale = new Vector3(scaleAmt, scaleAmt, scaleAmt);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
