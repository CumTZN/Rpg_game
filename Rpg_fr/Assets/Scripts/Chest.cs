using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emtychest;
    public int Amount = 5;
    protected override void OnCollide(Collider2D coll)
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emtychest;
            GameManager.instance.ShowText("+" + Amount + "gold" , 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }

    }
} 
