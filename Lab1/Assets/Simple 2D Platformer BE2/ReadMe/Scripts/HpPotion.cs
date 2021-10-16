
using UnityEngine;

public class HpPotion : MonoBehaviour
{
    [SerializeField] private int _hpPoints;

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            player.AddHp(_hpPoints);
            Destroy(gameObject);

        }
    }

}
