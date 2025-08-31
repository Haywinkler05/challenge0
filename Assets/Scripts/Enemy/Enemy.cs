using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnownPos;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }

    public Vector3 LastKnownPos { get => lastKnownPos; set => lastKnownPos = value; }
   
    public aiPath path;
    
    [Header("Sight values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85;
    public float eyeheight;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f,10)]   
    public float fireRate;
    [SerializeField]
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Intialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer();
        currentState = stateMachine.activeState.ToString();
       
    }
    public bool canSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeheight);
                float angleToPlayer = Vector3.Angle (targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeheight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {

                        if(hitInfo.transform.gameObject == player)
                        {
                            Debug.Log("Player hit");
                            return true;
                        }
                    }
                    
                }
            }
        }
        return false;
    }
}
