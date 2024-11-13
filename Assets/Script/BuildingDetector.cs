using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    private Vector3 lastPosition;
    private float moveThrsehold = 0.1f;
    private ConstructibleBuilding currentNearbyBuilding;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        CheckForBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어가 일정 거리 이상 이동했는지 체크
        if (Vector3.Distance(lastPosition, transform.position) > moveThrsehold)
        {
            CheckForBuilding();
            lastPosition = transform.position;
        }

        //가까운 아이템이 있고 E 키를 눌렀을 때 아이템 수집
        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());
        }
    }

    private void CheckForBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);   //감지 범위 내의 모든 콜라이더를 찾음

        float closesDistance = float.MaxValue;      //가장 가까운 거리의 초기값
        ConstructibleBuilding closestBuilding = null;         //가장 가까운 아이템 초기값

        foreach (Collider collider in hitColliders)  //각 콜라이더를 검사하여 수집 가능한 아이템을 찾음
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();        //아이템을 감지
            if (building != null && building.canBuild && !building.isConstructed) //아이템이 있고 수집 가능한지 확인
            {
                float distance = Vector3.Distance(transform.position, building.transform.position); //거리 계산
                if (distance < closesDistance)      //더 가까운 아이템을 발견 시 업데이트
                {
                    closesDistance = distance;
                    closestBuilding = building;
                }
            }
        }
        if (closestBuilding != currentNearbyBuilding)   //가장 가까운 아이템이 변경되었을 때만 메세지 표시
        {
            currentNearbyBuilding = closestBuilding;            //가장 가까운 아이템 업데이트
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.Show(
                    $"[F]키로 {currentNearbyBuilding.buildingName} 건설 (나무 {currentNearbyBuilding.requiredTree} 개 필요)",
                    currentNearbyBuilding.transform.position + Vector3.up
                );
            }
        }
    }
}
