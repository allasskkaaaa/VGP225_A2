using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ServerController : MonoBehaviour
{
    public NavMeshAgent serverAgent;
    ServerBaseState currentState;
    public ServerIdleState idleState = new ServerIdleState();
    public ServerWalkingState walkState = new ServerWalkingState();
    public ServerAttackState attackState = new ServerAttackState();
    public ServerAttackCooldownState attackCooldownState = new ServerAttackCooldownState();
    [SerializeField] private GameObject broom;

    private Animator animator;
    public int selectedTableIndex;
    [SerializeField] private float animationTransitionDuration;

    [SerializeField] public List<Transform> tables;

    [SerializeField] public float idleDuration = 2;
    [SerializeField] public float cooldownDuration = 2;
    [SerializeField] public float walkSpeed = 1.5f;

    public bool playerInStrikeRange = false;
    [SerializeField] private float playerStrikeRange = 5f;
    [SerializeField] public float rotationSpeed = 1f;

    [SerializeField] public Transform broomColliderSpawnPoint;
    [SerializeField] public GameObject broomColliderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        broom.SetActive(false);

        serverAgent = GetComponent<NavMeshAgent>();
        serverAgent.speed = walkSpeed;

        animator = GetComponent<Animator>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        isPlayerInStrikeRange();
    }

    public void PlayAnimation(string name)
    {
        animator.CrossFade(name, animationTransitionDuration);
    }

    public void SwitchState(ServerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void WalkToRandomTable()
    {
        selectedTableIndex = randomlySelectTableNumber(tables);

        if (selectedTableIndex != -1) // Ensure a valid index was returned
        {
            serverAgent.SetDestination(tables[selectedTableIndex].position);
        }
        else
        {
            Debug.LogWarning("No valid table was found, cannot move.");
        }
                
    }

    public int randomlySelectTableNumber(List<Transform> tableList)
    {
        if (tableList == null || tableList.Count == 0)
        {
            Debug.LogWarning("Table list is empty or null!");
            return -1; // Return an invalid index to indicate failure
        }

        int randomIndex = Random.Range(0, tableList.Count);
        Debug.Log("The random number is: " + randomIndex);

        return randomIndex;
    }

    private void isPlayerInStrikeRange()
    {
        if(Vector3.Distance(serverAgent.transform.position, PlayerStateManager.Instance.transform.position ) < playerStrikeRange)
        {
            playerInStrikeRange = true;
            Debug.Log("In strike range : " + playerInStrikeRange);
        }
        else
            playerInStrikeRange = false;
    }

    public void onEndOfAnimation()
    {
        currentState.OnAnimationEnded(this);
        Debug.Log("onEndOfAnimation() is called ");
    }

    public void SpawnBroomCollider()
    {
        Instantiate(broomColliderPrefab, broomColliderSpawnPoint.position, Quaternion.identity);

    }

    public void EnableBroom()
    {
        broom.SetActive(true);
    }

    public void DisableBroom()
    {
        broom.SetActive(false);
    }

}
