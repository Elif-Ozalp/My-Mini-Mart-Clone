using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    [SerializeField] Transform tomatoeStand;
    [SerializeField] Transform cashier;
    [SerializeField] Transform exit;
    [SerializeField] GameObject levelManager;
    [HideInInspector] public bool onPos1 = false;
    [HideInInspector] public bool onTheStand = false;
    [HideInInspector] public bool onCashier = false;
    public NavMeshAgent agent;
    private LevelManager _levelManager;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    void Start()
    {
       _levelManager = levelManager.GetComponent<LevelManager>();
      
    }

    void Update()
    {

        pos1 = tomatoeStand.position;
        pos1.x -= 25;
        pos2 = cashier.position ;
        pos2.x -= 20;
        pos2.z += 30;
        pos3= exit.position;
        pos3.x -= 25;

        var navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        if (navMeshAgent.enabled)
        {
            agent.SetDestination(pos1);
        }
     
        if (onTheStand )
        {
            int index = _levelManager.Customers.IndexOf(gameObject);
            if (index <= _levelManager.Positions.Count - 1)
            {
                if (!navMeshAgent.enabled)
                {
                    navMeshAgent.enabled = true;
                }
                agent.SetDestination(_levelManager.Positions[index].transform.position);
                StartCoroutine(SetRotation());
               
            }else if(index > _levelManager.Positions.Count - 1)
            {
                navMeshAgent.enabled = false;
            }
            
        }
       
        if ( onPos1 && navMeshAgent.enabled)
        {
            var firstCustomerInTheQueue = _levelManager.Customers[0];
            firstCustomerInTheQueue.GetComponent<NavMeshAgent>().SetDestination(pos2); 
        }
        if (onCashier && navMeshAgent.enabled)
        {  
            agent.SetDestination(pos3); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pos1"))
        {
           onPos1 = true;
        }
        else if (other.CompareTag ("Exit"))
        {
            LevelManager.Instance.RemoveFromCashierQueue(gameObject);
            ObjectPool.Instance.AddToPool(gameObject);
            gameObject.SetActive(false);
        }
    }

    IEnumerator SetRotation()
    {
        yield return new WaitForSeconds(5f);
        int index= _levelManager.Customers.IndexOf(gameObject);
        if (index == 0)
        {
            index = 1;
        }
        transform.LookAt(_levelManager.Customers[index-1].transform);
    }
   
}
