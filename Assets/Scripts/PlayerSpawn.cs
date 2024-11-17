using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefab;
    

    void Start()
    {
        LoadPlayer();
    }

    public void LoadPlayer()
    {
        Vector2 spawnPoint = transform.position;
        if (PlayerPrefs.HasKey("playerChoice"))
        {
            Instantiate(playerPrefab[PlayerPrefs.GetInt("playerChoice")], spawnPoint, Quaternion.identity);
        }
    }
}
