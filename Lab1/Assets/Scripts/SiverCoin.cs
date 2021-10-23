using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiverCoin : MonoBehaviour
{
    [SerializeField] private int _siverCoin;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            player.AddBronze(_siverCoin);
            Destroy(gameObject);
        }

    }
}
