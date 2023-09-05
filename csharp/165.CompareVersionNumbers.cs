public class Solution {
    public int CompareVersion(string version1, string version2) 
    {
        string[] version1Components = version1.Split('.');
        string[] version2Components = version2.Split('.');
        var maxLength = Math.Max(version1Components.Length, version2Components.Length);
        int i = 0;
        while (i < maxLength)
        {
            var ver1Element = i <= version1Components.Length - 1 ? version1Components[i] : "0";
            var ver2Element = i <= version2Components.Length - 1 ? version2Components[i] : "0";
            var ver1ElementInt = Convert.ToInt32(ver1Element);
            var ver2ElementInt = Convert.ToInt32(ver2Element);

            if (ver1ElementInt > ver2ElementInt)
            {
                return 1;
            }
            else if (ver1ElementInt < ver2ElementInt)
            {
                return -1;
            }

            i++;
        }

        return 0;
    }
}


// the solution should be pretty straight forward
// 1. split each version by '.'
// we will have 2 resulting arrays of numbers
// 2. calculate the biggest length and iterate over both
// 3. take elements with the same indexes from both arrays and convert.toint
// 4. compare two numbers if one of them bigger return -1 or 1 
// 5. if equals continue, increase indexes and compare next elements
// 5.1 if one of the arrays exhausted assume the elements from it are equals to 0
// 6. if both of arrays are exhausted return 0