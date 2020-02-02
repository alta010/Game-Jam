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
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.collider.gameObject.tag) {
            case "Water":
                Damage(2);
                break;
            case "Dust Bunny":
                Damage(4);
                break;
            case "Virus":
                Damage(8);
                break;
        }
    }
}
