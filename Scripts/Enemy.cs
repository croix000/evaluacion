using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float distanceThreshold;
    // Start is called before the first frame update
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (Vector3.Distance(player.gameObject.transform.position, transform.position) < distanceThreshold) {
            player.ModifyPower(-20);
        }
    }
}
