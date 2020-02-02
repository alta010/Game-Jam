using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public int maxHP;
    public int hp;

    void Start() {
        hp = maxHP;
    }

    void Update() {
        if (hp <= 0) {
            Kill();
        }
    }

    private void Kill() {
        Destroy(gameObject);
    }

    public void Damage(int dmg) {
        hp -= dmg;
    }
}
