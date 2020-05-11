using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private EventManager eventManager;
    [SerializeField] private ParticleSystem expParticle;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        targetRB = GetComponent<Rigidbody>();
        // Randomly select launch location
        transform.position = new Vector3(Random.Range(-5, 5), -5);

        // Randomly select the upward force
        targetRB.AddForce(Vector3.up * Random.Range(14, 19), ForceMode.Impulse);

        // Randomly select the spin force
        targetRB.AddTorque(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(expParticle, transform.position, expParticle.transform.rotation);
        Destroy(gameObject);
        if(CompareTag("Bad Target"))
        {
            eventManager.targetDestroyed?.Invoke(-10);
        }
        else if(CompareTag("Good Target"))
        {
            eventManager.targetDestroyed?.Invoke(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
