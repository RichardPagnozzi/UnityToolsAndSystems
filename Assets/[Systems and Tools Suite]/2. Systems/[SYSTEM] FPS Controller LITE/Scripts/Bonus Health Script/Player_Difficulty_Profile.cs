using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Difficulty Settings", menuName = "UTS/Spawn Player Difficulty Profile", order = 1)]
[System.Serializable]
public class Player_Difficulty_Profile : ScriptableObject
{
    [Header("Player Fortitude Settings")]
    [Range(100, 150)]
    public float playerHealth = 100;
    [Range(100, 200)]
    public float playerArmor = 100;
    [Header("Player Locomotion Settings")]
    [Range(1, 20)]
    public int baseSpeed = 12;
    [Range(2, 40)]
    public int sprintSpeed = 15;
    [Range(1, 20)]
    public int jumpSpeed = 12;
    [Range(10, 100)]
    public int gravity = 30;
    [Space(10)]
    [Header("Player Attack Settings")]
    [Range(0.75f, 1.15f)]
    public float damageScaler = 1;
}
