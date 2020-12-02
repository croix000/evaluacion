using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private PlayerController player;
    private void Start()
    {

        player.onRockJumped += backwards;
    }

    void backwards()
    {

        GetComponent<BatController>().backwards();
    }
}
