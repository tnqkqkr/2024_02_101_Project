using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //각각의 아이템 개수를 저장하는 변수
    public int crystalCount = 0;
    public int plantCount = 0;
    public int bushCount = 0;
    public int treeCount = 0;

    //아이템을 추가하는 함수, 아이템 종류에 따라 해당 아이템의 개수를 증가시킴
    public void AddItem(ItemType itemType)
    {
        //아이템 종류에 따른 다른 동작 수행
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++; //크리스탈 개수 증가
                Debug.Log($"크리스탈 획득! 현재 개수 :{crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++; //식물 개수 증가
                Debug.Log($"식물 획득! 현재 개수 :{plantCount}");
                break;
            case ItemType.Bush:
                bushCount++; //수풀 개수 증가
                Debug.Log($"수풀 획득! 현재 개수 :{bushCount}");
                break;
                case ItemType.Tree:
                treeCount++; //나무 개수 증가
                Debug.Log($"나무 획득! 현재 개수 :{treeCount}");
                break;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowInventory()
    {
        Debug.Log("====인밴토리====");
        Debug.Log($"크리스탈:{crystalCount}개");
        Debug.Log($"식물:{plantCount}개");
        Debug.Log($"수풀:{bushCount}개");
        Debug.Log($"나무:{treeCount}개");
        Debug.Log("================");
    }
}
