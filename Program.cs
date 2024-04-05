using System.Text;

namespace Assignment2
{
    internal class Program
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
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
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
                // Question 1 - Code
                if (nums.Length == 0)
                    return 0;

                int k = 1; // At least one unique element exists.

                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is different from the previous one,We're adding it to the unique elements.
                    if (nums[i] != nums[i - 1])
                    {
                        nums[k] = nums[i]; // Placing the unique element in the correct position
                        k++; // Incrementing the count of unique elements
                    }
                }
                return k; // we have { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 } in array, now it will return 5 unique numbers.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 1-Self Reflection:
         This code aims to remove duplicate elements from an integer array while preserving the order of unique elements.
        Initialized a pointer 'k' to track unique elements in the array. 
        It iterates through the array, placing each unique element in its correct position.
        Comparing the current element with the previous one to identify duplicates.
        If the current element is different from the previous one, it's considered unique.
        The count of unique elements is returned as the new length of the array.
        Exception handling is included for robustness, though not essential here. 
        */


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
                if (nums == null || nums.Length == 0)
                    return new List<int>(); // Return an empty list if input is null or empty

                int nonZeroPointer = 0; // Pointer to track the position for non-zero elements

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is non-zero,move it to the position pointed by nonZeroPointer
                    if (nums[i] != 0)
                    {
                        nums[nonZeroPointer] = nums[i];
                        nonZeroPointer++;
                    }
                }
                // Fill the remaining positions with zeros
                while (nonZeroPointer < nums.Length)
                {
                    nums[nonZeroPointer] = 0;
                    nonZeroPointer++;
                }
                // Convert the modified array to a list and return
                return nums.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* 2-Self Reflection 
         This method aims to move all zero elements to the end of the array while preserving the order of non-zero elements.
        It employs a simple two-pointer approach for efficient rearrangement of elements.
        It utilizes a two-pointer approach, with one pointer tracking the position for non-zero elements. 
        Iterating through the array, If the current element is non-zero, move it to the position pointed by nonZeroPointer. Converting the modified array to a list and returning
        The code ensures robustness by handling cases where the input array is null or empty.
        */


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
                Array.Sort(nums); // Sort the array to facilitate the two-pointer approach
                IList<IList<int>> result = new List<IList<int>>();

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;
                    int left = i + 1; // Left pointer
                    int right = nums.Length - 1; // Right pointer
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];

                        if (sum == 0)
                        {
                            // Add the triplet to the result
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++; // Move left pointer towards right to increase the sum
                        }
                        else
                        {
                            right--; // Move right pointer towards left to decrease the sum
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

        /* 3- Self Reflection
        Implements an algorithm to find all unique triplets in an array whose sum equals zero.
        It employs a two-pointer approach along with sorting the array for efficiency.
        Move left pointer towards right to explore other combinations.
        Move right pointer towards left to explore other combinations
        The code ensures to skip duplicates and handles edge cases gracefully. 
        Exception handling is included for additional safety, though it's not particularly necessary in this context.
        */


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
                int maxConsecutiveOnes = 0;
                int currentConsecutiveOnes = 0;

                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        currentConsecutiveOnes++;
                        maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes);
                    }
                    else
                    {
                        currentConsecutiveOnes = 0;
                    }
                }
                return maxConsecutiveOnes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 4-Self Reflection
        This method aims to find the maximum number of consecutive ones in a binary array.
        It iterates through the array, tracking consecutive ones and updating the maximum count as needed.
        Initialize variables to keep track of maximum consecutive ones and current consecutive ones. Iterate through each element of the array.Check if the current element is 1, indicating a consecutive sequence.Increment the count of consecutive ones.Update the maximum count of consecutive ones if necessary.If the current element is not 1, the consecutive sequence is broken.Return the maximum count of consecutive ones found
        */

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
                int decimalValue = 0;
                int baseMultiplier = 1; // To keep track of the current position's base

                while (binary > 0)
                {
                    int lastDigit = binary % 10; // Extract the last digit of the binary number
                    decimalValue += lastDigit * baseMultiplier; // Update the decimal value
                    binary /= 10; // Remove the last digit from the binary number
                    baseMultiplier *= 2; // Move to the next higher power of 2
                }
                return decimalValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* 5-Self Reflection:
        This method aims to convert a binary number to its equivalent decimal representation.
        It employs a iterating through each digit of the binary number and updating the decimal value.
        It starts with initializing variables, then iterates through each digit of the binary number, updating the decimal value accordingly. Each step is commented for clarity, making it easy to follow the logic of the code. Exception handling is included for robustness, though not particularly essential in this specific scenario. Overall, this structured approach ensures that the code is easily understandable and maintainable.
        */

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
                if (nums.Length < 2)
                    return 0;

                int maxGap = 0;

                // Find the minimum and maximum elements in the array
                int minNum = nums[0];
                int maxNum = nums[0];

                foreach (int num in nums)
                {
                    minNum = Math.Min(minNum, num);
                    maxNum = Math.Max(maxNum, num);
                }

                // Calculate the size of each bucket
                int bucketSize = Math.Max(1, (maxNum - minNum) / (nums.Length - 1));

                // Calculate the number of buckets
                int numBuckets = (maxNum - minNum) / bucketSize + 1;

                // Initialize buckets
                int[] minBucket = new int[numBuckets];
                int[] maxBucket = new int[numBuckets];
                bool[] hasValue = new bool[numBuckets];

                // Place elements into buckets
                foreach (int num in nums)
                {
                    int bucketIndex = (num - minNum) / bucketSize;
                    minBucket[bucketIndex] = hasValue[bucketIndex] ? Math.Min(minBucket[bucketIndex], num) : num;
                    maxBucket[bucketIndex] = hasValue[bucketIndex] ? Math.Max(maxBucket[bucketIndex], num) : num;
                    hasValue[bucketIndex] = true;
                }

                // Calculate the maximum gap
                int prevMax = minNum;
                for (int i = 0; i < numBuckets; i++)
                {
                    if (hasValue[i])
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - prevMax);
                        prevMax = maxBucket[i];
                    }
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 6 - Self Reflection:
        This method aims to find the maximum gap between elements after sorting the array.
        It utilizes the concept of bucketing to efficiently determine the maximum gap.
         It first identifies the minimum and maximum elements in the array. Then, it divides the range of numbers into buckets based on the size of the gap. Next, it places each element into its corresponding bucket. Finally, it calculates the maximum gap by comparing adjacent buckets.
         Exception handling is included for robustness, though it's not particularly necessary in this specific scenario. Overall, this structured approach ensures clarity and efficiency in solving the problem.
        

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
                Array.Sort(nums); // Sort the array in non-decreasing order
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                    {
                        // If the current triplet forms a valid triangle, return its perimeter
                        return nums[i] + nums[i - 1] + nums[i - 2];
                    }
                }

                // No valid triangle found
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 7 Self Reflection:
        This method aims to find the largest perimeter of a triangle that can be formed by selecting three elements from the array.
        It sorts the array and then iterates over it to find the largest valid triangle perimeter.
        It first sorts the array in non-decreasing order to make it easier to identify valid triangles. Then, it iterates over the array, starting from the largest elements, and checks if the current triplet forms a valid triangle by comparing the sum of two smaller sides with the largest side.
        If a valid triangle is found, it returns its perimeter; otherwise, it returns 0.
        Each step is clearly commented for clarity, making it easy to understand the logic behind the code. 

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
                while (s.Contains(part))
                {
                    int index = s.IndexOf(part); // Find the index of the leftmost occurrence of part
                    s = s.Remove(index, part.Length); // Remove part from s starting at index
                }
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 8 Self Reflection:
        This method aims to remove all occurrences of a specified substring 'part' from the input string 's'.
        It repeatedly searches for the leftmost occurrence of 'part' in 's' and removes it until no more occurrences are found.
        This method implements a simple algorithm to remove all occurrences of a specified substring 'part' from the input string 's'. It iteratively searches for the leftmost occurrence of 'part' in 's' using the IndexOf method and removes it using the Remove method until no more occurrences are found. Each step is commented for clarity, making it easy to understand the logic behind the code.
        */

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
