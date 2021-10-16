using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeCoin : MonoBehaviour
{
    [SerializeField] private int _bronzecoin;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            player.AddBronze(_bronzecoin);
            Destroy(gameObject);
        }
      
    }

}
