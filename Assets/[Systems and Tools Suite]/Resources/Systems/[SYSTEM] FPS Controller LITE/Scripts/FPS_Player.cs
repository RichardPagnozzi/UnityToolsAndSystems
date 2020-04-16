using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("Richs FPS Scripts/Health and XP")]
public class FPS_Player : MonoBehaviour
{

    #region Variables
    public Player_Difficulty_Profile DifficultySettings;
    [Tooltip("Players Current Level")]
    [SerializeField]
    private float LVL;
    [Header("Health Points")]
    [SerializeField]
    private float HP_max;
    [SerializeField]
    private float HP_cur;
    [Header("Armor Points")]
    [SerializeField]
    private float AMR_max;
    [SerializeField]
    private float AMR_cur;
    [SerializeField]
    [Header("Experience Points")]
    private float XP_max;
    [SerializeField]
    private float XP_cur;
    [SerializeField]
    private float damageScaler;
    [SerializeField]
    private bool isDead = false;
    private bool damaged = false;
    #endregion Variables

    #region Factory Methods
    void Awake()
    {
        HP_max = DifficultySettings.playerHealth;
        AMR_max = DifficultySettings.playerArmor;
        HP_cur = HP_max;
        damageScaler = DifficultySettings.damageScaler;
        XP_cur = 0;
        XP_max = 1000;
        LVL = 1;
    }

    private void OnEnable()
    {
        HP_max = DifficultySettings.playerHealth;
        AMR_max = DifficultySettings.playerArmor;
        HP_cur = HP_max;
        damageScaler = DifficultySettings.damageScaler;
    }

    void Update()
    {
        HealthMonitor();
        damaged = false;

        if (XP_cur >= XP_max)
        {
            XP_cur = 0;
            XP_max *= 1.5f;
        }
    }
    #endregion Factory Methods

    private void HealthMonitor()
    {
        if (HP_cur <= 0)
        {
            HP_cur = 0;
            isDead = true;
        }
    }

    public bool IsDead() { return isDead; }

    #region Public Methods
    public void DamagePlayer(float damageAmnt)
    {
        HP_cur -= damageAmnt * damageScaler;
        damaged = true;
    }
    public float GetHealth()
    {
        return HP_cur;
    }
    public float GetMaxHealth()
    {
        return HP_max;
    }
    public void AddHealth(float hp)
    {
        HP_cur += hp;
    }
    public void AddMaxHealth(float hp)
    {
        HP_max += hp;
    }
    public float GetXP()
    {
        return XP_cur;
    }
    public void AddXP(int xp)
    {
        XP_cur += xp;
    }
    public void SubXP(int xp)
    {
        XP_cur -= xp;
    }
    public void SetMaxXP(int xp)
    {
        XP_max = xp;
    }
    public float GetMaxXP()
    {
        return XP_max;
    }
    public void AddLevel()
    {
        LVL += 1;
    }
    public void ResetLevels()
    {
        LVL = 1;
    }
    public float GetLevel()
    {
        return LVL;
    }
    #endregion Public Methods

}
