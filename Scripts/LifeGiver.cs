using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGiver : MonoBehaviour
{
    private bool passed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!passed && other.tag == "Player")
        {

            other.GetComponent<PlayerController>().LifeStoneCollision();
            passed = true;
        }
    }
}
