using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    
    public GameObject player2Follow; //la posicion de Rambo, del player principal
    public float stopDistance;
    public float speed = 1;
    public bool moviendoIzquierda;

    // Start is called before the first frame update
    public virtual void Start() //Virtual es para poder sobreescribir el método específico
    {
        if (player2Follow == null) //Si no tienes un player a quien seguir, buscalo por el tag PLAYER
        {
            player2Follow = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player2Follow != null)
        {
            if (Vector2.Distance (transform.position, player2Follow.transform.position) > stopDistance)
            {
                Vector2 direccion;
                direccion = Vector2.MoveTowards(transform.position, player2Follow.transform.position, speed * Time.deltaTime);
                this.transform.position = direccion;
            }

        }

        Vector3 direction = player2Follow.transform.position - transform.position;
        if (direction.x >= 0.0f)
        {
            //moviendoIzquierda = !moviendoIzquierda;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //speed = speed * -1; // velocidad *= -1;
        } else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        //speed = speed * -1; // velocidad *= -1;


        if (player2Follow == null) //Si no tienes un player a quien seguir, buscalo por el tag PLAYER
        {
            player2Follow = GameObject.FindGameObjectWithTag("Player");
        }
    }

    

}
