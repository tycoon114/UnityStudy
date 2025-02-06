using UnityEngine;

public class ItemData
{
    public string itemName;
    [TextArea] public string itemDesccription;

    public ItemData()
    {

    }

    public ItemData(string itemName, string itemDesccription)
    {
        this.itemName = itemName;
        this.itemDesccription = itemDesccription;
    }


    public string getItemName(string Name)
    { 
        return Name; 
    }

    public string getItemDescript(string Descxript)
    {
        return Descxript;
    }

    public string setItemName(string Name)
    {
        return Name;
    }

    public string setItemDes(string Des)
    {
        return Des;
    }

    public string DataGet(string text, string desc) => $"{text},{desc}";

    public static ItemData DataSet(string data)
    {

        string[] data_value = data.Split(',');

        return new ItemData(data_value[0], data_value[1]);
    }


}
