using System;
using UnityEngine;

//[Flags]
//public enum FRUIT
//{
//    None = 0,
//    a = 1 << 0,
//    s = 1 << 1,
//    d = 1 << 2,

//}


[AddComponentMenu("customUtil/shChungDay02")]
public class Day02Review : MonoBehaviour {

    public bool onGround = true;

    public string[] fruitBasket;

    public int money;

    [Range(1, 99)]
    public int fieldView;

    public string rainbow;


}
