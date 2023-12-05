using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {
    public GameObject player;
    Vector3 pos = new Vector3(0f, 15f, -10f);

    void Update() {
        transform.position = player.transform.position + pos;
    }
}
