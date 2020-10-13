using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace UTS
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private GameObject[] Enemies;

        [SerializeField]
        private bool ToggleSpawn;

        public UnityEvent waveClearedEvent;

        private int totalEnemies = 0;
        private int totalKilled = 0;
        private bool waveCleared = false;
        private bool enemiesSpawnedIn = false;
        #endregion Variables

        // Start is called before the first frame update
        private void Awake()
        {
            if (Enemies != null)
                totalEnemies = Enemies.Length;
        }
        private void Update()
        {
            if (ToggleSpawn)
            {
                SpawnEnemies();
            }

            if (enemiesSpawnedIn && GetWaveClearedStatus() == true)
            {
                waveClearedEvent?.Invoke();
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && !enemiesSpawnedIn)
            {
                SpawnEnemies();
            }
        }

        private void SpawnEnemies()
        {
            if (totalEnemies != 0)
            {
                for (int i = 0; i < totalEnemies; i++)
                {
                    Enemies[i].SetActive(true);
                }
            }

            ToggleSpawn = false;
            enemiesSpawnedIn = true;
        }

        private bool GetWaveClearedStatus()
        {
            totalKilled = 0;
            for (int i = 0; i < totalEnemies; i++)
            {
                if (Enemies[i] == null)
                    totalKilled++;
            }

            if (totalKilled == totalEnemies)
            {
                return waveCleared = true;
            }
            else
            {
                return waveCleared = false;
            }

        }
    }
}