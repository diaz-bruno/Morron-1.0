using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulgon : MonoBehaviour
{
    Rigidbody2D pulgonRb;       // variable de tipo Rigidbody2D. Para guardar componentes en una variable
    BoxCollider2D pulgonCol;    // y acceder a ellss a desde codigo
    SpriteRenderer pulgonRend;  //

    

    // SerializeField es para poder modificar esta variable desde el inspector de Unity
    // Sino no se muestra. 
    [SerializeField] private float speed;   //Velocidad del objeto 
    [SerializeField] private float verticalForce; // Fuerza para el salto que da cuando muere.

    
    void Start()
    {
        pulgonRb = GetComponent<Rigidbody2D>(); // Aca se guarda el componente del objeto en la variable
        pulgonCol = GetComponent<BoxCollider2D>(); // que declaramos mas arriba
        pulgonRend = GetComponent<SpriteRenderer>();

        if (transform.position.x <= 0){
            transform.Rotate(new Vector3(0,180,0));
        }   
    }

    private void OnMouseUp(){
        pulgonCol.isTrigger = true; /*tildamos la casilla IsTrigger cuando se clickea el objeto
         IsTrigger activa o desactiva la colision. */
        pulgonRend.color = Color.grey; //Cambiamos el color del objeto. 
        pulgonRb.AddTorque(-5,ForceMode2D.Impulse);// Impulso de giro (Fuerza, tipo de fuerza aplicada)
        pulgonRb.AddForce(new Vector2(0,verticalForce)); // Impulso hacia arriba
        speed = 0; // deja de moverse el objeto.     

    }

    void FixedUpdate() //Es como el update nomral pero optimizado para las físicas. 
    {
        transform.Translate(speed * Time.deltaTime,0,0);

        if (transform.position.y <= -6f){  //Si el objeto se cae del mapa, -6 en eje Y, se Destruye.
            Destroy(gameObject);  //Aca gameObject hace referencia al objeto donde esta aplicado el script.
            Debug.Log("Me Destrui"); //Avisa que se destruyó.
        }
        
    }
}
