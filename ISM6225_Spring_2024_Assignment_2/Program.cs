using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                int n = nums.Length;
                List<int> missingNumbers = new List<int>();

                // Mark indexes corresponding to present numbers
                for (int i = 0; i < n; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (index >= 0 && index < n)
                    {
                        nums[index] = -Math.Abs(nums[index]);
                    }
                }

                // Add indices which remain positive => missing numbers
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0)
                    {
                        missingNumbers.Add(i + 1);
                    }
                }

                return missingNumbers;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in FindMissingNumbers: input array might be malformed.", ex);
            }

            // Edge Cases:
            // - Empty array -> return empty list
            // - All elements present -> return empty list
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        (nums[left], nums[right]) = (nums[right], nums[left]);
                    }

                    if (nums[left] % 2 == 0) left++;
                    if (nums[right] % 2 == 1) right--;
                }

                return nums;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in SortArrayByParity.", ex);
            }

            // Edge Cases:
            // - Empty array -> return empty
            // - All even or all odd -> unchanged
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> numDict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (numDict.ContainsKey(complement))
                    {
                        return new int[] { numDict[complement], i };
                    }
                    if (!numDict.ContainsKey(nums[i]))
                    {
                        numDict[nums[i]] = i;
                    }
                }

                return new int[0]; // No match found
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in TwoSum: check array size and target.", ex);
            }

            // Edge Cases:
            // - No two elements add up to target -> returns empty array
            // - Duplicates present
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                    throw new ArgumentException("Input array must contain at least three integers.");

                int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
                int min1 = int.MaxValue, min2 = int.MaxValue;

                foreach (int num in nums)
                {
                    // Track max three
                    if (num > max1)
                    {
                        (max3, max2, max1) = (max2, max1, num);
                    }
                    else if (num > max2)
                    {
                        (max3, max2) = (max2, num);
                    }
                    else if (num > max3)
                    {
                        max3 = num;
                    }

                    // Track two minimums
                    if (num < min1)
                    {
                        (min2, min1) = (min1, num);
                    }
                    else if (num < min2)
                    {
                        min2 = num;
                    }
                }

                return Math.Max(max1 * max2 * max3, min1 * min2 * max1);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in MaximumProduct: check array for null or insufficient elements.", ex);
            }

            // Edge Cases:
            // - Array with large negative numbers
            // - Less than 3 numbers -> throws exception
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber < 0)
                    throw new ArgumentException("Negative numbers are not supported.");

                if (decimalNumber == 0) return "0";

                var binary = new System.Text.StringBuilder();
                while (decimalNumber > 0)
                {
                    binary.Insert(0, decimalNumber % 2);
                    decimalNumber /= 2;
                }

                return binary.ToString();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in DecimalToBinary: check input value.", ex);
            }

            // Edge Cases:
            // - Negative input -> throws exception
            // - Input = 0 -> returns "0"
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0) // Check for null or empty array
            {
                throw new ArgumentException("Input array cannot be null or empty.");
            }

            try
            {
                if (nums == null || nums.Length == 0)
                    throw new ArgumentException("Input array cannot be null or empty.");

                int left = 0, right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else if (nums[mid] < nums[right])
                    {
                        right = mid;
                    }
                    else
                    {
                        right--;
                    }
                }

                return nums[left];
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while finding the minimum element.", ex);
            }

            // Edge Cases:
            // - Array not rotated (already sorted)
            // - All elements are the same
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0 || (x != 0 && x % 10 == 0)) return false;

                int reversedHalf = 0;
                while (x > reversedHalf)
                {
                    reversedHalf = reversedHalf * 10 + (x % 10);
                    x /= 10;
                }

                return x == reversedHalf || x == reversedHalf / 10;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in IsPalindrome.", ex);
            }
            // Edge Cases:
            // - Negative input -> false
            // - Input ending in 0 (except 0 itself) -> false
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0)
                    throw new ArgumentException("Input must be a non-negative integer.");

                if (n == 0) return 0;
                if (n == 1) return 1;

                int prev1 = 0, prev2 = 1;
                for (int i = 2; i <= n; i++)
                {
                    (prev1, prev2) = (prev2, prev1 + prev2);
                }

                return prev2;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in Fibonacci: check if n is non-negative.", ex);
            }

            // Edge Cases:
            // - n = 0 or 1 -> return n directly
            // - n < 0 -> throw exception
        }
    }
}
