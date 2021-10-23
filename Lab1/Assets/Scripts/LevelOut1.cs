using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int _coinsToNextLevel;
    [SerializeField] private int _levelTolaod;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _finichOutSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        if (player != null && player.Coins > _coinsToNextLevel)
        {
            _spriteRenderer.sprite = _finichOutSprite;
            SceneManager.LoadScena
         
        }

    }



}
