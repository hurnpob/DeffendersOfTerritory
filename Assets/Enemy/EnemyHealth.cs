using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    VisualEffect smokePoof;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;
    Enemy enemy;




    void OnEnable()
    {
        currentHitPoints = maxHitPoints;        
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        smokePoof = GetComponent<VisualEffect>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        //smokePoof.Play();
    }

    void ProcessHit() 
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
    private void Update()
    {
       
    }
}
