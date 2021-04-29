using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP;
    public int HP;
    bool wasJustHit = false;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void hit() {
        HP -= 1;
        wasJustHit = true;
    }

    public float getHealthPercent() {
        return (float)HP/(float)maxHP;
    }

    public int getHealth() {
        return HP;
    }

    public bool isAlive() {
        return HP > 0;
    }

    public bool justHit() {
        if (wasJustHit) {
            wasJustHit = false;
            return true;
        } else {
            return false;
        }
    }
}
