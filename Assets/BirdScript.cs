using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private int maxYBound = 24;
    private int minYBound = -24;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) {
            myRigidbody.velocity = Vector2.up * flapStrength; //Vector2 only describes X and Y values, used in 2D game development. In this case, Vectpr2.up represents vector (0, 1)
        }
        if (transform.position.y >= maxYBound || transform.position.y <= minYBound) {
            death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        death();
    }

    void death() 
    {
        logic.tryGameOver();
        birdIsAlive = false;
    }
}
