using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private PlayerController player;
    private void Start()
    {

        player.onRockJumped += backwards;
    }

    void backwards() {

        transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
    }
}
