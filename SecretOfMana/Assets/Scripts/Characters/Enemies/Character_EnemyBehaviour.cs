using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Character_EnemyBehaviour : VisualCharacter
{
    //MEMBERS
    //*******

    //publics
    public float ViewAngle { get; private set; }
    public float ViewRadius { get; private set; }
    public bool IsTargetInFov { get; private set; }
    public Transform Target { get; private set; }

    //privates
    private LayerMask _targetMask;
    private LayerMask _obstaclesMask;

    private float _moveSpeed = 4.0f;
    private float _rotationSpeed = 20.0f;
    private float _attackRange = 2.0f;
    private float _attackTimer = 0.0f;
    private const float _attackDelay = 1.0f;

    private NavMeshAgent _navMeshAgent;

    //METHODS
    //*******
    private void Start()
    {
        ViewRadius = 6.0f;
        ViewAngle = 110.0f;

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;

        //A Layermask is a bitmask. An integer has 32 bits
        //The bit shift operator is setting up this mask by taking number 1 (binary) 
        //and shifting (rotating around) the number effectively moving the number 1 to the left
        _obstaclesMask = 1 << 8;
        _targetMask = 1 << 9;

        StartCoroutine(FindTargetsWithDelay(0.1f));
    }

    private void Update()
    {
        if(IsTargetInFov)
        {
            FollowTarget();
        }
    }

    public IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    private void FindVisibleTargets()
    {
        IsTargetInFov = false;

        //Only detect the current active character
        var selectedCharacter = GameManager.Instance().CharacterManager.SelectedCharacter.VisualCharacter.gameObject;

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, ViewRadius, _targetMask.value);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            if(targetsInViewRadius[i].gameObject == selectedCharacter)
            {
                Target = targetsInViewRadius[i].transform;

                Vector3 dirToTarget = (Target.transform.position - this.transform.position).normalized;

                //Check if we are in the view angle
                if (Vector3.Angle(transform.forward, dirToTarget) < ViewAngle / 2)
                {
                    //Check if there is no obstacle in between the enemy and target
                    if (!Physics.Raycast(transform.position, dirToTarget, ViewRadius, _obstaclesMask))
                    {
                        IsTargetInFov = true;
                        
                    }
                }
            }
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private void FollowTarget()
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.destination = Target.position;
    }
}
