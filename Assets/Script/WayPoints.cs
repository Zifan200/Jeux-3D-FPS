using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPoints : MonoBehaviour
{
    [SerializeField] 
    private GameObject waypointsParent;

    private List<Vector3> waypoints;

    private int currentWPIndex;  
    private NavMeshAgent agent; 
    EnnemiLogic ennemiLogic;
    // Start is called before the first frame update
    void Start()
    {
        ennemiLogic = GetComponent<EnnemiLogic>();
        // Récupérer les waypoints
        waypoints = new List<Vector3>();

        // Ajouter les positions des enfants de waypointsParent dans la liste waypoints
        foreach(Transform t in waypointsParent.GetComponentsInChildren<Transform>())
        {
            waypoints.Add(t.position);
        }
        waypoints.Remove(waypointsParent.transform.position);

        agent = GetComponent<NavMeshAgent>();

        currentWPIndex = 0;
        agent.SetDestination(waypoints[currentWPIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        suivreWaypoints();
    }

    private void suivreWaypoints(){
        if(agent.remainingDistance <= agent.stoppingDistance && ennemiLogic.isPatrolling)
        {
            currentWPIndex = ++currentWPIndex % waypoints.Count;
            agent.SetDestination(waypoints[currentWPIndex]);
        }
    }
}
