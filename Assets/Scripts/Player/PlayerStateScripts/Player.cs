using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStateController StateController { get; private set; }


    public PlayerIdleState PlayerIdle { get; private set; }
    public PlayerMoveState PlayerMove { get; private set; }
    public PlayerHideState PlayerHide { get; private set; }


    public Animator Anim { get; private set; }

    [SerializeField] private PlayerData playerData;


    private void Awake()
    {
        StateController = new CharacterStateController();

        PlayerIdle = new PlayerIdleState(this, StateController, playerData, "idle");
        PlayerMove = new PlayerMoveState(this, StateController, playerData, "moving");
        PlayerHide = new PlayerHideState(this, StateController, playerData, "hiding");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();

        StateController.Initialize(PlayerIdle);
    }

    private void Update()
    {
        StateController.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateController.CurrentState.PhysicsUpdate();
    }
}
