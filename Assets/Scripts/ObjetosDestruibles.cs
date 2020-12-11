using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosDestruibles : MonoBehaviour
{
    [SerializeField] private string objectType;
    [SerializeField] private int turboToAdd;
    public GameObject destuctibleObject;
    public GameObject explosion;
    public BoostBar turboBar;
    private CarController carcontroller;
    

    // Start is called before the first frame update
    void Start()
    {
        carcontroller = GameObject.FindGameObjectWithTag("BoxCollider3").GetComponent<CarController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hurtPlayer(int damage)
    {
        carcontroller.vehicleHealth -= damage;
    }

    public void healPlayer(int heal)
    {
        carcontroller.vehicleHealth += heal;
    }

    public void increasedSpeed(int speed)
    {
        carcontroller.forwardAccel = speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoxCollider3" && objectType == "TNT")
        {
            
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject destrutibleBox = Instantiate(destuctibleObject, transform.position, transform.rotation) as GameObject;
            Rigidbody[] allRigibodies = destrutibleBox.GetComponentsInChildren<Rigidbody>();
            if (allRigibodies.Length > 0)
            {
                foreach(var body in allRigibodies)
                {
                    body.AddExplosionForce(500, transform.position, 1);
                }
            }
            hurtPlayer(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BoxCollider3" && objectType == "Mesa")
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject destrutibleBox = Instantiate(destuctibleObject, transform.position, transform.rotation) as GameObject;
            Rigidbody[] allRigibodies = destrutibleBox.GetComponentsInChildren<Rigidbody>();
            if (allRigibodies.Length > 0)
            {
                foreach (var body in allRigibodies)
                {
                    body.AddExplosionForce(500, transform.position, 1);
                }
            }
            healPlayer(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BoxCollider3" && objectType == "Basurero")
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject destrutibleBox = Instantiate(destuctibleObject, transform.position, transform.rotation) as GameObject;
            Rigidbody[] allRigibodies = destrutibleBox.GetComponentsInChildren<Rigidbody>();
            if (allRigibodies.Length > 0)
            {
                foreach (var body in allRigibodies)
                {
                    body.AddExplosionForce(500, transform.position, 1);
                }
            }
            AddTurbo(turboToAdd);
            Destroy(gameObject);
        }
    }

    private void AddTurbo(int turbo)
    {
        carcontroller.currentTurbo += turbo;
        turboBar.SetTurbo(carcontroller.currentTurbo);

    }
}
