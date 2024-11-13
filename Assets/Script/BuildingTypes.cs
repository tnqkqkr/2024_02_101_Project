using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingType
{
    CraftingTalbe,                  //제작대
    Furnace,                        //용광로
    Kitchen,                        //주방
    Storage                         //창고
}

[System.Serializable]
public class CraftingRecipe
{
    public string itemName;                         //제작할 아이템 이름
    public ItemType resultItem;                     //결과물
    public int resuItAmount = 1;                    //결과물 개수
    public ItemType[] requireditems;                //필요한 재료들
    public int[] requiredAmounts;                   //필요한 재료 개수
}
