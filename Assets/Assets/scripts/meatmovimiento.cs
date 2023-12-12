using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatmovimiento : MonoBehaviour
{
    float xInicial, yInicial;
    public GameObject Bulletprefab;
    public float speed;
    public float jumpforce;

    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    private float Horizontal;
    private bool grounded;
    private float LastShoot;
    private int Health = 7;
   
    

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        xInicial = transform.position.x;
        yInicial = transform.position.y;
    }

    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.2334012f, 0.2441467f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.2334012f, 0.2441467f, 1.0f);

        animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }
        else grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
                
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot +0.25F)

        {
            Shoot();
            LastShoot = Time.time;
        }


    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpforce);

    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.2334012f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(Bulletprefab, transform.position +direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScritp>().Setdirection(direction);
    } 
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
