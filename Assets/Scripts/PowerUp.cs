using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static PowerUp instancePowerUp;
    public GameObject powerUp;
    public Transform[] spawnLocation;
    [HideInInspector] public GameObject powerUpfab;
  
    private void Awake()
    {
        if (instancePowerUp == null && instancePowerUp!= this)
        {
            instancePowerUp = this;
        }
        else
        {
            instancePowerUp = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }

    public void spawnPowerUp()
    {
        
        powerUpfab = Instantiate(powerUp, spawnLocation[Random.Range(0, spawnLocation.Length)]);
        powerUpfab.SetActive(true);
    }


}
