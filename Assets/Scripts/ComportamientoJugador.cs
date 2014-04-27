using UnityEngine;
using System.Collections;

public class ComportamientoJugador : MonoBehaviour {

	public float velocidadMaxima = 0.1f;
	public float velocidadSalto = 5f;
	bool miraDerecha = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velocidadSalto);
		}
	}

	// FixedUpdated no necesita deltaTime, se usa para las fisicas.
	void FixedUpdate () {
		float movimiento = Mathf.Min(Mathf.Abs(Input.GetAxis("Horizontal")), 0.25f);
		if(Input.GetAxis("Horizontal") < 0){
			movimiento *= -1;
		}

		rigidbody2D.velocity = new Vector2(movimiento*velocidadMaxima, rigidbody2D.velocity.y);

		if(movimiento > 0 && !miraDerecha){
			girar();
		}else if(movimiento < 0 && miraDerecha){
			girar();
		}
	}

	void girar(){
		miraDerecha = !miraDerecha;
		Vector3 miEscala = transform.localScale;
		miEscala.x *= -1;
		transform.localScale = miEscala;
	}

}
