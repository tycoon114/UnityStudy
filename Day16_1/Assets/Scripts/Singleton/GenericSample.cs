using UnityEngine;

public class GenericSample : MonoBehaviour
{

    //배열을 전달 받아 배열의 요소를 순서대로 출력하는 코드
    public static void printArray(int[] numbers) {
        for (int i = 0; i < numbers.Length; i++) { 
            Debug.Log(numbers[i]);
        
        }
    }


    public static void printFArray(float[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);

        }
    }

    public static void printSArray(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log(words[i]);

        }
    }

    public static void printGArray<T>(T[] values) {
        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);

        }
    }


    void Start()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6 };
        float[] numbers2 = { 1.1f, 4.3f, 234.3f };
        string[] strings = { "asdf", "ㅁㄴㅇㄹ", "123asd" };

        printGArray<int>(numbers);
        printGArray(numbers2);
        printGArray<string>(strings);
    }

    void Update()
    {
        
    }
}
