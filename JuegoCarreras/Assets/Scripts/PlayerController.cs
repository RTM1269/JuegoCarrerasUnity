using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public WheelCollider delanteraIzquierda;
    public WheelCollider delanteraDerecha;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.centerOfMass = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //v.21:00
        verticalInput = 15f * Input.GetAxis("Vertical");
        //rigidBody.AddForce(0,0,50);
        delanteraIzquierda.motorTorque = 5 * verticalInput;
        delanteraDerecha.motorTorque = 5 * verticalInput;
        //rigidBody.transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * 5);
        rigidBody.transform.position = transform.position + transform.forward * verticalInput * Time.deltaTime;


        float rotation = 30f * Input.GetAxis("Horizontal");
        //Seteo la rotación de la rueda izquierda sobre el eje y relativa del vehículo en ese momento, según la tecla pulsada. 
        delanteraIzquierda.transform.localEulerAngles = new Vector3(0, rotation, 0);
        //Seteo la rotación de la rueda derecha sobre el eje y relativa del vehículo en ese momento, según la tecla pulsada. 
        delanteraDerecha.transform.localEulerAngles = new Vector3(0, rotation, 0);
        // rigidBody.transform.Rotate(0f, rotation * Time.deltaTime, 0f);
        //rigidBody.transform.Rotate(0f, rotation*delanteraIzquierda.radius* delanteraDerecha.radius * Time.deltaTime, 0f);
        // rigidBody.transform.rotation=Quaternion.Euler(new Vector3(0, rotation/2* Time.deltaTime, 0));
        rigidBody.transform.Rotate(new Vector3(0, rotation * Time.deltaTime * 2, 0));

    }
}
 