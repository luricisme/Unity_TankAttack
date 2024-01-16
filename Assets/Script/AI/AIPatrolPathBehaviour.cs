using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolPathBehaviour : MonoBehaviour
{
    public PatrolPath patrolPath;
    [Range(0.1f, 1)]
    public float arriveDistance = 1;
    public float waitTime = 0.5f;
    [SerializeField]
    private bool isWaiting = false;
    [SerializeField]
    Vector2 currentPatrolTarget = Vector2.zero;
    bool isInitialized = false;

    private int currentIndex = -1;

    private void Awake()
    {
        if (patrolPath == null)
            patrolPath = GetComponentInChildren<PatrolPath>();
    }

    public void PerformAction(AutoTankControler tankController)
    {
        if (!isWaiting)
        {
            if (patrolPath.Length < 2)
                return;
            if (Vector2.Distance(tankController.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine(tankController));
                return;
            }
            Vector2 directionToGo = currentPatrolTarget - (Vector2)tankController.transform.position;
            var dotProduct = Vector2.Dot(tankController.transform.up, directionToGo.normalized);

            if (dotProduct < 0.98f)
            {
                var crossProduct = Vector3.Cross(tankController.transform.up, directionToGo.normalized);
                int rotationResult = crossProduct.z >= 0 ? -1 : 1;
                tankController.HandleMove(new Vector2(rotationResult, 1));
            }
            else
            {
                tankController.HandleMove(Vector2.up);
            }
        }
    }

    IEnumerator WaitCoroutine(AutoTankControler tankController)
    {
        yield return new WaitForSeconds(waitTime);
        var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
        currentPatrolTarget = nextPathPoint.Position;
        currentIndex = nextPathPoint.Index;
        isWaiting = false;
    }
}

