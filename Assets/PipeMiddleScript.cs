using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BoxCollider2D middleBox;
    public BoxCollider2D topBox;
    public BoxCollider2D bottomBox;


    // Start is called before the first frame update
    void Start()
    {
        // finds the FIRST GameObject in the hierarchy with the tag "Logic"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        middleBox.size = new Vector2(2, 15.3f);
        topBox.size = new Vector2(1.44f, 3.84f);
        bottomBox.size = new Vector2(1.44f, 3.84f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
    }

}
