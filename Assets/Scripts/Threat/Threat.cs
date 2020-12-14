using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threat : MonoBehaviour
{
    
    public ThreatStateController StateController { get; private set; }
    public ThreatIdleState ThreatIdle { get; private set; }
    public ThreatChaseState ThreatChase { get; private set; }
    public ThreatAttackState ThreatAttack { get; private set; }

    public Animator Anim;
    public Rigidbody2D Rb2d;
    public SpriteRenderer SpriteRenderer;
    [SerializeField] private ThreatData threatData;

    [SerializeField] public Transform player;


    void Awake()
    {
        StateController = new ThreatStateController();

        ThreatIdle = new ThreatIdleState(this, StateController, threatData, "idle");
        ThreatChase = new ThreatChaseState(this, StateController, threatData, "chase");
        ThreatAttack = new ThreatAttackState(this, StateController, threatData, "attack");
    }

    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StateController.Initialize(ThreatIdle);
        //StartCoroutine(StartChasing());
    }

    
    void Update()
    {
        StateController.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        StateController.CurrentState.PhysicsUpdate();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    //Functions

    IEnumerator StartChasing()
    {
        yield return new WaitForSeconds(120);
        transform.position = new Vector2(11, -1);
        Rb2d.gravityScale = 1;
    }
}
