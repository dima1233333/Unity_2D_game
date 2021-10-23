using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField] private int _goldCoin;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            player.AddBronze(_goldCoin);
            Destroy(gameObject);
        }

    }
}
