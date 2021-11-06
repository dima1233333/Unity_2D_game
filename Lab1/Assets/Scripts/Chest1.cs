using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest1 : MonoBehaviour
{
    [SerializeField] private int _coinsAmount;

    [SerializeField] private Sprite _openedChest;
    private SpriteRenderer _spriteRenderer;

    private Sprite _closedChest;

    //private bool _tryOpen;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _closedChest = _spriteRenderer.sprite;
    }
    public bool Activated { private get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Activated)
            return;


        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null)
        {
            _spriteRenderer.sprite = _openedChest;
            //_tryOpen = true;
            player.CoinsAmount += _coinsAmount;
            Debug.Log("Coins" + _coinsAmount);
        }
    }

}