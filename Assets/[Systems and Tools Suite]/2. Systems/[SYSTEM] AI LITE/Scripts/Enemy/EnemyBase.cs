using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Enemy_Health
{
    [Header("Enemy Health Variables")]
    [Tooltip("Is the enemy alive or dead")]
    public bool m_Alive;
    [Tooltip("This enemy's maximum health")]
    public float m_maxHealth;
    [Tooltip("This enemy's current health")]
    public float m_currentHealth;
}

[System.Serializable]
public class Enemy_Damage
{
    [Header("Enemy Damage Output Variables")]
    [Tooltip("This enemy's base damage amnt")]
    public float m_baseDamage;
}

[System.Serializable]
public class Enemy_Targeting
{
    [Header("Enemy Targeting Variables listed below")]
    [Tooltip("Drag and drop the eyes here (for raycasting)")]
    public GameObject Eyes;
    [Tooltip("The Range at which the player must be to trigger pursuit")]
    public float m_pursuitRange;
    [Tooltip("The Range at which the player must be to trigger pursuit")]
    public float m_chaseRange;
    [Tooltip("The Range at which the Enemy will stop pursuing the player")]
    public float m_attackRange;
    [Tooltip("The Speed at which the Enemy will pursue the player")]
    public float m_chaseSpeed;
    [Tooltip("The radius the enemy can wander within")]
    public float m_wanderRadius;
    [Tooltip("The interval duration between wandering")]
    public float m_wanderInterval;

    [Space(2)]

    [Header("Drag and Drop Variables")]
    [Tooltip("GameObject to Target")]
    public GameObject Player;
    [Tooltip("Array of Patrol Points")]
    public GameObject[] PatrolPoints;
}

[System.Serializable]
public class Enemy_FX
{
    [Header("VFX Variables")]
    public GameObject BloodDecal;
    public GameObject BloodVFX;
    public GameObject SpawnVFX;
}


public abstract class EnemyBase : MonoBehaviour
{
    #region Variables
    [HideInInspector]
    public StateMachine m_StateMachine;
    [Header("Enemy Health Variables")]
    public Enemy_Health EnemyHealth;
    [Header("Enemy Damage Variables")]
    public Enemy_Damage EnemyDamage;
    [Header("Enemy Targeting Variables")]
    public Enemy_Targeting EnemyTargeting;
    [Header("Enemy FX Variables")]
    public Enemy_FX EnemyFX;
    [Space(2)]
    [Header("Enemy Experience Worth")]
    public float XP_Worth;
    public GameObject[] XPdrops;
    private bool dropped = false;
    #endregion Variables


    public void TakeDamage(float amnt)
    {
        if (EnemyHealth.m_Alive)
        {
            EnemyHealth.m_currentHealth -= amnt;
            if (EnemyHealth.m_currentHealth <= 0)
            {
                EnemyHealth.m_currentHealth = 0;
                EnemyHealth.m_Alive = false;
            }
        }
    }
    public void DropXP(float xp_Amnt)
    {
        Vector3 dropPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        switch (xp_Amnt)
        {   // 0  1   2   
            // 5, 10, 25 - XP drop amnts

            case 10:
                {
                    if (dropped == false)

                    {
                        Instantiate(XPdrops[0], Random.insideUnitSphere + dropPos, transform.rotation);
                        Instantiate(XPdrops[0], Random.insideUnitSphere + dropPos, transform.rotation);
                        dropped = true;
                    }
                    break;

                }
            case 25:
                {
                    if (dropped == false)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Instantiate(XPdrops[0], Random.insideUnitSphere + dropPos, transform.rotation);
                        }
                        dropped = true;
                    }
                    break;
                }
            case 50:
                {
                    if (dropped == false)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Instantiate(XPdrops[1], Random.insideUnitSphere + dropPos, transform.rotation);
                        }
                        dropped = true;
                    }
                    break;
                }
            case 75:
                {
                    if (dropped == false)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Instantiate(XPdrops[2], Random.insideUnitSphere + dropPos, transform.rotation);
                        }
                        dropped = true;
                    }
                    break;
                }
            case 100:
                {
                    if (dropped == false)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Instantiate(XPdrops[2], Random.insideUnitSphere + dropPos, transform.rotation);
                        }
                    }
                    break;
                }
            case 200:
                {
                    if (dropped == false)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            Instantiate(XPdrops[2], Random.insideUnitSphere + dropPos, transform.rotation);
                        }
                        dropped = true;
                    }
                    break;
                }

        }
    }

}
