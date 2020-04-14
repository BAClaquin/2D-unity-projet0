using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{

    PlayerCharacter player;
    public GameObject explosion;

    public int damage  = 10;

    [Range(0,100)]
    public float maxSpeed;

    [Range(0, 100)]
    public float minSpeed;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        print("collision ma gueule");
        if (hitObject.tag == "Player" && player != null)
        {
            print("collision ma gueule");
            player.inflictDamage(damage);
        }
        Destroy(gameObject);
    }
}
