/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Xml;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                int i = 0;// Index for unique elements
                for (int j = 1; j < nums.Length; j++) // Loop through array starting from 2nd element
                {
                  if (nums[i] != nums[j]) // If adjacent elements are different then Move to next position for unique element
                    {
                        i++;
                        nums[i] = nums[j]; //Store the element
                    }
                }
                return i + 1; // returning size of the array of unique elements i.e. count

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int left = 0; // Pointer for iterating through the array
                int right = 0; // Pointer for placing non-zero elements

                // Move non-zero elements to the front of the array
                while (left < nums.Length)
                {
                    if (nums[left] != 0)
                    {
                        // Swap non-zero element to the right position
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                        right++;
                    }
                    left++;
                }
                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                List<IList<int>> result = new List<IList<int>>();
                Array.Sort(nums); // Sort the array to optimize the solution

                for (int i = 0; i < nums.Length - 2; i++) // Loop through the array up to the second last element
                {
                    if (i == 0 || (i > 0 && nums[i] != nums[i - 1])) // Avoid duplicate triplets by skipping identical elements
                    {
                        int left = i + 1;
                        int right = nums.Length - 1;
                        int target = -nums[i]; // Calculate the target sum

                        while (left < right)
                        {
                            int sum = nums[left] + nums[right]; // Calculate sum of current elements

                            if (sum == target)
                            {
                                result.Add(new List<int> { nums[i], nums[left], nums[right] }); // Add triplet to result
                                while (left < right && nums[left] == nums[left + 1]) left++; // Avoid duplicate elements in left pointer
                                while (left < right && nums[right] == nums[right - 1]) right--; // Skip duplicate elements in right pointer
                                left++; // Move left pointer
                                right--; // Move right pointer
                            }
                            else if (sum < target) // If sum is less than target, move left pointer to increase sum
                            {
                                left++;
                            }
                            else
                            {
                                right--; // else move right pointer to decrease sum
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int mainCount = 0; // Variable to keep track of consecutive ones
                int temp = 0; // Temporary variable to store the current count of consecutive ones

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 1)
                    {
                        temp++; // Increment temp if the current element is 1
                    }
                    else
                    {
                        if (temp > mainCount)
                        {
                            mainCount = temp; // Update mainCount if temp is greater
                        }
                        temp = 0; // Reset temp when the current element is 0
                    }
                }

                // Check if temp is greater than mainCount after iterating through the array
                if (temp > mainCount)
                {
                    mainCount = temp;
                }

                return mainCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalNum = 0;
                int baseValue = 1; // Initialize base value to 2^0

                // Iterate over each digit of the binary number
                while (binary > 0)
                {
                    int lastDigit = binary % 10; // Get the last digit
                    binary = binary / 10; // Remove the last digit from the binary number

                    // Add the contribution of the current digit to the decimal number
                    decimalNum += lastDigit * baseValue;

                    // Update base value for the next iteration (multiply by 2)
                    baseValue *= 2;
                }

                return decimalNum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                int n = nums.Length;

                if (n < 2)
                {
                    return 0;
                }

                // Find minimum and maximum elements in the array
                int minValue = int.MaxValue;
                int maxValue = int.MinValue;

                foreach (int num in nums)
                {
                    minValue = Math.Min(minValue, num);
                    maxValue = Math.Max(maxValue, num);
                }

                // Calculate the size of each bucket
                int bucketSize = Math.Max(1, (maxValue - minValue) / (n - 1));

                // Calculate the number of buckets
                int bucketCount = (maxValue - minValue) / bucketSize + 1;

                // Initialize buckets
                int[][] buckets = new int[bucketCount][];
                for (int i = 0; i < bucketCount; i++)
                {
                    buckets[i] = new int[] { int.MaxValue, int.MinValue };
                }

                // Place elements into buckets
                foreach (int num in nums)
                {
                    int index = (num - minValue) / bucketSize;
                    buckets[index][0] = Math.Min(buckets[index][0], num);
                    buckets[index][1] = Math.Max(buckets[index][1], num);
                }

                // Calculate the maximum gap
                int maxGap = 0;
                int prevMax = minValue;

                for (int i = 0; i < bucketCount; i++)
                {
                    if (buckets[i][0] != int.MaxValue)
                    {
                        maxGap = Math.Max(maxGap, buckets[i][0] - prevMax);
                        prevMax = buckets[i][1];
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in non-decreasing order
                Array.Sort(nums);
                Array.Reverse(nums);

                // Iterate through the array to find the largest perimeter
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    int a = nums[i];
                    int b = nums[i + 1];
                    int c = nums[i + 2];

                    // Check if the current triplet forms a triangle with non-zero area
                    if (a < b + c)
                    {
                        return a + b + c; // Return the largest perimeter
                    }
                }

                // If no such triangle found, return 0
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                int partLength = part.Length; // Store the length of the substring 'part'
                int index = s.IndexOf(part); // Find the index of the first occurrence of 'part' in 's'

                // Check if the substring 'part' is not found in 's'
                if (index == -1)
                {
                    return s; // If 'part' is not found, return the original string
                }

                // Initialize a string builder to efficiently remove 'part' occurrences
                var sb = new System.Text.StringBuilder(s);

                // Remove all occurrences of 'part' from 's'
                while (index != -1)
                {
                    sb.Remove(index, partLength);
                    index = sb.ToString().IndexOf(part); // Find the next occurrence of 'part' in the modified string
                }

                return sb.ToString(); // Return the string with all occurrences of 'part' removed
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}