using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;
    public bool is_Player;

    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;



        if(health <= 0f) {
            animationScript.DEATH();
            characterDied = true;

            if(is_Player) {

            }
            return;
        }
        if (!is_Player){
            if (knockDown){
                if(Random.Range(0,2) > 0) {
                    animationScript.KnockDown();
                }
            }else{

                if (Random.Range(0, 3) > 1){
                    animationScript.HIT();
                }
            }
        }
        


    }//apply damage
    
}//class






































