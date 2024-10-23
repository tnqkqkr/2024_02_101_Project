using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;          //상태 머신에 대한 참조 (이후 구현)
    protected PlayerController playerController;        //플레이어 컨트롤러에 대한 참조
    protected PlayerAnimationManager animationManager;  //애니메이션 매니저를 가져온다.

    //생성자: 상태 머신과 플레이어 컨트롤러 참조 초기화
    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        this.playerController = stateMachine.PlayerController;
        this.animationManager = stateMachine.GetComponent<PlayerAnimationManager>();
    }

    //가상 메서드들: 하위 클래스에서 필요에 따라 오버드라이드
    public virtual void Enter() { }     //상태 진입 시 호출
    public virtual void Exit() { }      //상태 종료시 호출
    public virtual void Update() { }
    public virtual void FixedUpdate() { }

    //상태 전환과 조건을 체크하는 메서드
    protected void CheckTransitions()
    {
        if (playerController.isGrounded())
        {
            //지상에 있을 때의 상태 전환 로직
            if(Input.GetKeyDown(KeyCode.Space))             //스페이스를 눌렀을때
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //이동키가 눌렸을때
            {
                stateMachine.TransitionToState(new MovingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new IdleState(stateMachine));
            }
        }
        else
        {
            if (playerController.GetVerticalVelocity() > 0)         //받아온 Y축 속도 값이 + 일때
            {
                stateMachine.TransitionToState(new JumpingState(stateMachine));
            }
            else
            {
                stateMachine.TransitionToState(new FallingState(stateMachine)); //받아온 Y축 속도 값이 - 일때 [낙하 상태]
            }
        }
    }
}

public class IdleState : PlayerState
{
    public IdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }
}
//MovingState : 플레이어가 정지해 있는 상태
public class MovingState : PlayerState
{
    private bool isRunning;
    public MovingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        //달리기 입력 확인
        isRunning = Input.GetKey(KeyCode.LeftShift);

        CheckTransitions();
    }
    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}
//JupingState : 플레이어가 점프 상태일때
public class JumpingState : PlayerState
{
    public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }
    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}
//FallingState : 플레이어가 낙하 중일때
public class FallingState : PlayerState
{
    public FallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        CheckTransitions();
    }
    public override void FixedUpdate()
    {
        playerController.HandleMovement();
    }
}