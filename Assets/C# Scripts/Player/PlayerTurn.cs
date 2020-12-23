using SpriteActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    playerMeleeAttack meleeAttack = new playerMeleeAttack();
    playerRangeAttack rangeAttack = new playerRangeAttack();
    Vector3 enemyVector;
    Collider2D targetedEnemy;
    
    UITextcontrol UItext;
    bool melee;

    public bool Melee { get => melee; set => melee = value; }

    // Start is called before the first frame update
    void Start()
    {
        UItext = new UITextcontrol();
        melee = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D target = GetComponent<PlayerTargeting>().mouseSelection();
        
        if (target != null) {
            Debug.Log(target.gameObject.name);
            if (target.gameObject.tag == "Enemy")
            {
                targetedEnemy = GetComponent<PlayerTargeting>().mouseSelection();
                UItext.sendingToUI(targetedEnemy.name);
            }
        }
        
    }

    public void attackMelee() {
        int damageDone;
        int targetDC;
        int targetHealth;
        //Debug.LogWarning(targetedEnemy.name);
        if (targetedEnemy != null)
        {
            //Debug.LogWarning("attacking");
            targetDC = targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Armorclass;
            targetHealth = targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Health;
            if (melee)
            {
                damageDone = meleeAttack.execute(targetDC, GetComponent<Transform>(), targetedEnemy.transform);
                if (damageDone < 0)
                {
                    melee = true;
                    damageDone = 0;
                }
                else {
                    melee = false;
                }
                targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Health = targetHealth - damageDone;
                UItext.sendingToUI("Attacked for " + damageDone + " target is now on " + targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Health);
            }

        }
        //melee = false;
    }

    public void attackRange()
    {
        int damageDone;
        int targetDC;
        int targetHealth;
        //Debug.LogWarning(targetedEnemy.name);
        if (targetedEnemy != null)
        {
            //Debug.LogWarning("attacking");
            targetDC = targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Armorclass;
            targetHealth = targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Health;
            if (melee)
            {
                damageDone = rangeAttack.execute(targetDC, GetComponent<Transform>(), targetedEnemy.transform);
                if (damageDone < 0)
                {
                    melee = true;
                    damageDone = 0;
                }
                else
                {
                    melee = false;
                }
                targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Health = targetHealth - damageDone;
                UItext.sendingToUI("Attacked for " + damageDone + " target is now on " + targetedEnemy.gameObject.GetComponent<SpriteAttributes>().Attributes.Health);
            }

        }
        //melee = false;
    }
    public void resetAttack()
    {
        melee = true;
        UItext.sendingToUI("Your attack has been reset");
    }


    
}
