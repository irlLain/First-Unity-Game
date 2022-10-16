using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullets : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
        if (transform.position.x > 15 && transform.position.y < 4 && transform.position.y > -4)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Shooting");
        }

    }

}
