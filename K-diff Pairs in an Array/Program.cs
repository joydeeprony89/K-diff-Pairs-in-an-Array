using System;
using System.Collections.Generic;

namespace K_diff_Pairs_in_an_Array
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 1, 3, 1, 5, 4 };
      int k = 0;
      Solution s = new Solution();
      var answer = s.FindPairs(nums, k);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int FindPairs(int[] nums, int k)
    {
      // Step 1 - Count the frequency of each unique array elements and create a map
      // Step 2 - we have two scenarios
      // Scenario 1 - if k > 0, we need to find x + k is present in the map
      // x is the array element and why x + k, we need to kind x - another no = k, which can be written as k + x = another no, so for each x we will check the map contains the another no
      // Scenario 2 - if k == 0, for this case as the difference is 0 we just need to find the unique elements from the array or the keys in our frequency map where the count is more than 1.
      Dictionary<int, int> frequency = new Dictionary<int, int>();
      foreach (int i in nums)
      {
        if (!frequency.ContainsKey(i)) frequency.Add(i, 0);
        frequency[i]++;
      }

      int result = 0;
      var keys = frequency.Keys;
      foreach (int key in keys)
      {
        if (k > 0 && frequency.ContainsKey(key + k) || (k == 0 && frequency[key] > 1)) result++;
      }

      return result;
    }
  }
}
