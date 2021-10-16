using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCoin : MonoBehaviour
{
    [SerializeField] private int _chestcoin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            player.AddChestCoin(_chestcoin);
        }
    }
}
