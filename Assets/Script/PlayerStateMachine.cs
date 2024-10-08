using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currenState;
    public PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //초기 상태를 IdleState 로 설정
        TransitionToState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        //현재 상태가 존재한다면 해당 상태의 Update 메서드 호출
        if (currenState != null)
        {
            currenState.Update();
        }
    }

    private void FixedUpdate()
    {
        //현재 상태가 존재한다면 해당 상태의 FixedUpdate 메서드 호출
        if (currenState != null)
        {
            currenState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newState)
    {
        //현재 상태가 존재한다면 Exit 메서드를 호출
        currenState?.Exit();        //검사해서 호출 종료 (?)는 IF 조건

        //새로운 상태로 전환
        currenState = newState;

        //새로운 상태의 Enter 메서드 호출 (상태 시작)
        currenState.Enter();

        //로그에 상태 전환 정보를 출력
        Debug.Log($"상태 전환 되는 스테이드 : {newState.GetType().Name}");
    }
}
