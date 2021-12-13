using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnMovement : MonoBehaviour
{
    public int force;

    public bool bouncyObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AutoKill");
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(-transform.right * force, ForceMode2D.Force);
        //this.GetComponent<Rigidbody2D>().transform.Translate(-Vector3.forward,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hitting the player");

            if (bouncyObject)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1) * collision.GetComponent<UpgradesShop>().bounciness);
            }

            Destroy(this.gameObject);
        }
    }

    IEnumerator AutoKill() 
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    private void BouncyObject()
    {

    }
}

