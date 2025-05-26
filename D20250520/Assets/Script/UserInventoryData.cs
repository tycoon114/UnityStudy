using System;
public class UserInventoryData
{
    //식별자 규칙 : 획득 연월일 + 난수 4자리
    //private readonly long _serialNumber;
    //private readonly int _itemId;


    public long SerialNumber { get; }
    public int ItemId { get; }  


    public static readonly System.Random random = new System.Random();
    public  static UserInventoryData Acquire(int itemId)
    {
        int rndNum = random.Next(10000);
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMdd") + rndNum.ToString("D4"));

        return new UserInventoryData(serialNumber, itemId);
    }

    public UserInventoryData(long serialNumber, int itemId)
    {
        SerialNumber = serialNumber;
        ItemId = itemId;
    }

    public override string ToString()
    {
        return $"data   {SerialNumber}, {ItemId}";
    }

}
