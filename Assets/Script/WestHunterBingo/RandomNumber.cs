using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RandomNumber : MonoBehaviour
{

   public static List<int> GenerateRandomNumbers(int count, int min, int max)
    {
        List<int> numbers = new List<int>();
        List<int> pool = new List<int>();
        for (int i = min; i <= max; i++)
        {
            pool.Add(i);
        }
        for (int i = 0; i < pool.Count; i++)
        {
            int randIndex = Random.Range(0, pool.Count);
            int temp = pool[i];
            pool[i] = pool[randIndex];
            pool[randIndex] = temp;
        }
        for (int i = 0; i < count; i++)
        {
            numbers.Add(pool[i]);
        }
        return numbers;
     }
}
