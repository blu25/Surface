using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioSource explore;
    public AudioSource fight;
    public TransitionController tc;

    public float musicLevel = 0.4f;

    float exploreVol = 1f;
    float fightVol = 0f;

    float goalExploreVol = 1f;
    float goalFightVol = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkForFight();

        if (exploreVol < goalExploreVol) {
            exploreVol += Time.deltaTime;
        } else if (exploreVol > goalExploreVol) {
            exploreVol -= Time.deltaTime;
        }

        if (fightVol < goalFightVol) {
            fightVol += Time.deltaTime;
        } else if (fightVol > goalFightVol) {
            fightVol -= Time.deltaTime;
        }

        explore.volume = exploreVol * musicLevel;
        fight.volume = fightVol * musicLevel;
    }

    public void checkForFight() {
        if (tc.inTransitionOut()) {
            stopMusic();
            return;
        }

        bool playerInCombat = false;
        EnemyController[] ec = FindObjectsOfType<EnemyController>();
        foreach(EnemyController e in ec) {
            if (e.inCombat()) {
                playerInCombat = true;
            }
        }
        if (playerInCombat) {
            startCombat();
        } else {
            stopCombat();
        }
    }

    public void stopMusic() {
        goalExploreVol = 0f;
        goalFightVol = 0f;
    }

    public void startCombat() {
        goalExploreVol = 0f;
        goalFightVol = 1f;
    }

    public void stopCombat() {
        goalExploreVol = 1f;
        goalFightVol = 0f;
    }
}
