using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject Bulletprefab;
    public GameObject Meat;

    private float LastShoot;
    private int Health = 1;

    private void Update()
    {
        if (Meat == null) return;

        Vector3 direction = Meat.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.2272429f, 0.2472372f, 1.0f);
        else transform.localScale = new Vector3(-0.2272429f, 0.2472372f, 1.0f);

        float distance = Mathf.Abs(Meat.transform.position.x - transform.position.x);

        if (distance < 0.5f && Time.time > LastShoot +0.25f)
        {
            Shoot();
            LastShoot= Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.2272429f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(Bulletprefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScritp>().Setdirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
    
    
      
    
}
