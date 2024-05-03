using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector3 distance;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        distance = this.transform.position - player.transform.position;
        Debug.Log("Distance=" + distance);
    }

    // Update is called once per frame
   private void lateUpdate()
    {
        this.transform.position = player.transform.position + distance;
    }
}
