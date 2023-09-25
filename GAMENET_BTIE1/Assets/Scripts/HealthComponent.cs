using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviourPunCallbacks
{
    private float startHealth = 100;
    public float health;

    [SerializeField] Image healthbar;

    void Start()
    {
        health = startHealth;
        healthbar.fillAmount = health / startHealth;
    }

    [PunRPC]
    void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log(health);

        healthbar.fillAmount = health / startHealth;

        if(health <= 0){
            Die();
        }
    }

    private void Die()
    {
        if(photonView.IsMine)
            GameManager.instance.LeaveRoom();
    }
}
