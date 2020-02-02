using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHP;
    public int hp;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("U R DED");
    }

    private void Damage(int dmg) {
        hp -= dmg;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // DamageScript dmg = collission.collider.gameObject.GetComponent<DamageScript>();
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
