using Gpm.Ui;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotData : InfiniteScrollData
{ 
    public Sprite GradeBackGroundSprite { get; }
    public Sprite ItemIconSprite { get; }

}


public class InventoryItemSlot : InfiniteScrollItem
{

    [SerializeField] private Image _gradeBackGround;
    [SerializeField] private Image _itemIcon;
    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        InventoryItemSlotData data = scrollData as InventoryItemSlotData;

        //���� ������ �������� �����ϱ�
        _gradeBackGround.sprite = data.GradeBackGroundSprite;
        _itemIcon.sprite = data.ItemIconSprite;

    }
}
