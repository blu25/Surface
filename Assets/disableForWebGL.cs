using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableForWebGL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        // Workaround to fix mouse over-sensitivity in webgl version
        Destroy(gameObject);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
