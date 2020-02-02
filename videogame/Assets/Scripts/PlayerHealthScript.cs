using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxHP;
    public int hp;

    void Start() {
        hp = maxHP;
    }
    
    void Update() {
        if (hp <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("U R DED");
    }

    public void Damage(int dmg) {
        hp -= dmg;
        if (hp < 0) hp = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        EnemyHealthScript enemyHealth = collision.gameObject.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null) {
            Damage(enemyHealth.maxHP);
        }
    }
}
