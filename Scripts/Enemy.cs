using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Vector3 _direction = Vector2.left;
    public float speed = 5f;
    public System.Action killed;
    public int manykilled = 0;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;

        
    }


}
