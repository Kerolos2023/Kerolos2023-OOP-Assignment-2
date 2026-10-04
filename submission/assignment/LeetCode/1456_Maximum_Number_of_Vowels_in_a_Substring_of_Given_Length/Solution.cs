public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int count = 0;
        int maxCount = 0;
        int left = 0;
        
        for (int right = 0; right < s.Length; right++)
        {
            if (IsVowel(s[right]))
            {
                count++;
            }

            if (right - left + 1 > k)
            {
                if (IsVowel(s[left]))
                {
                    count--;
                }
                left++;
            }

            maxCount = Math.Max(maxCount, count);
        }

        return maxCount;
    }
        

    private bool IsVowel(char c)
    {
        return c == 'a' ||
               c == 'e' ||
               c == 'i' ||
               c == 'o' ||
               c == 'u';
    }
}