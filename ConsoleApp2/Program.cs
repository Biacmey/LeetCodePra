using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] num = {1,2,3};
            // int[] num2 = { 1, 2, 3 };
            // permute(num2);
            // string s = "";
            // Console.Write();
            LetterCombinations2("23");
            Console.ReadKey();
        }

        public static int StrStr(string haystack, string needle)
        {
            int num = 0;
            haystack.IndexOf(needle);
            return num;
        }

        #region --- LeetCode --- 暫無整理

        public static List<List<int>> permute(int[] nums)
        {
            List<List<int>> res = new List<List<int>>();
            if (nums.Length == 0 || nums == null)
                return res;
            List<int> list = new List<int>();
            list.Add(nums[0]);
            res.Add(list);
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < res.Count(); j++)
                {
                    for (int k = 0; k <= res[0].Count(); k++)
                    {
                        List<int> temp = new List<int>(res[0]);
                        // temp.Add(k,nums[i]);
                        res.Add(temp);
                    }
                    res.RemoveAt(0);
                }
            }
            return res;
        }

        #region Merge Sort
        static public void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[mid * 2];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }
            while (left <= eol)
                temp[pos++] = numbers[left++];
            while (mid <= right)
                temp[pos++] = numbers[mid++];
            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void SortMerge(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                SortMerge(numbers, left, mid);
                SortMerge(numbers, (mid + 1), right);
                MainMerge(numbers, left, (mid + 1), right);
            }
        }



        #endregion

        #region NONONO
        //public static string Convert(string s, int numRows)
        //{
        //    string graph = "";
        //    List<char> list = new List<char>();
        //    char[,] array = new Char[s.Length, numRows];
        //    int col = 0, row = 0, flag = 0, longf = s.Length;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        for (int j = 0; j < numRows; j++)
        //        {

        //            array[i, j] = s[flag];
        //            flag++;
        //            if (flag == s.Length)
        //            {
        //                break;
        //            }
        //            if (j == (numRows - 1) && numRows != 1 && j != 0)
        //            {
        //                for (int k = 0; ; k++)
        //                {
        //                    if (j == 1 || j == 0)
        //                        break;
        //                    if (flag == s.Length)
        //                    {
        //                        break;
        //                    }
        //                    i++;
        //                    j--;
        //                    array[i, j] = s[flag];
        //                    flag++;

        //                }
        //                break;
        //            }
        //        }
        //        if (flag == s.Length)
        //        {
        //            break;
        //        }
        //    }

        //    for (int i = 0; i < numRows; i++)
        //    {
        //        for (int j = 0; j < s.Length; j++)
        //        {
        //            if (array[j, i] != '\0')
        //            {
        //                list.Add(array[j, i]);
        //            }
        //        }
        //    }

        //    foreach (var c in list)
        //    {
        //        graph += c;
        //    }

        //    return graph;
        //}


        public IList<string> LetterCombinations(string digits)
        {
            IList<string> list = new List<string>();

            return list;
        }


        public static bool IsSymmetric(TreeNode root)
        {
            TreeNode left = root;
            TreeNode right = root;
            TreeNode cur = root;
            while (cur != null)
            {
                if (left.val != right.val)
                {
                    return false;
                }
            }
            return true;
        }


        #endregion

        #endregion

        #region Node
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        #endregion

        #region TreeNode
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        #endregion

        #region --- 3 --- 无重复字符的最长子串
        public static int LengthOfLongestSubstring(string s)
        {
            int ans = 0;
            List<char> tempp = new List<char>();
            List<char> temp = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (!temp.Contains(s[j]))
                    {
                        temp.Add(s[j]);
                    }
                    else
                    {

                        break;
                    }
                }
                if (ans < temp.Count)
                {
                    ans = temp.Count;
                    tempp = temp;
                }
                temp.Clear();
            }
            return ans;
        }
        #endregion

        #region --- 4 --- 寻找两个正序数组的中位数
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double ans = 0;
            List<int> list = new List<int>();
            int leg = nums1.Length + nums2.Length;
            int s1 = 0, s2 = 0;
            if (leg % 2 == 0)
            {
                for (int i = 0; i < leg; i++)
                {
                    if (s1 >= nums1.Length)
                    {
                        list.Add(nums2[s2]);
                        s2++;
                    }
                    else if (s2 >= nums2.Length)
                    {
                        list.Add(nums1[s1]);
                        s1++;
                    }
                    else
                    {
                        if (nums1[s1] < nums2[s2])
                        {
                            list.Add(nums1[s1]);
                            s1++;
                        }
                        else
                        {
                            list.Add(nums2[s2]);
                            s2++;
                        }
                    }

                    if ((list.Count - 1) == (leg / 2))
                    {
                        ans = list[(list.Count - 1)] + list[(list.Count - 2)];
                        ans = ans / 2;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < leg; i++)
                {
                    if (s1 >= nums1.Length)
                    {
                        list.Add(nums2[s2]);
                        s2++;
                    }
                    else if (s2 >= nums2.Length)
                    {
                        list.Add(nums1[s1]);
                        s1++;
                    }
                    else
                    {
                        if (nums1[s1] < nums2[s2])
                        {
                            list.Add(nums1[s1]);
                            s1++;
                        }
                        else
                        {
                            list.Add(nums2[s2]);
                            s2++;
                        }
                    }
                    if ((list.Count - 1) == (leg / 2))
                    {
                        ans = list[(list.Count - 1)];
                        break;
                    }
                }

            }

            return ans;
        }
        #endregion

        #region --- 5 --- 最長回文
        //寫一個判斷是否為回文的函式，每當找到前後相同的字串就傳進去判斷，取最長的。
        //Manacher演算法為找回文使用的演算法，將時間複雜度提升到O(n)
        public static string LongestPalindrome(string s)
        {
            if (s.Length ==1 || s.Length == 0)
            {
                return s;
            }

            string temp = s[0].ToString();
            for (int i = 0; i<s.Length; i++)
            {
                if (s.Length-i < temp.Length)
                {
                    break;
                }
                for (int j = s.Length-1; j >0 ; j--)
                {
                    if (j-i < temp.Length)
                    {
                        break;
                    }
                    if (s[i] == s[j])
                    {
                        if (j-i >= temp.Length && isPalindrome(s.Substring(i, j - i +1 )))
                        {
                            temp = s.Substring(i, j - i+1);
                        }
                    }
                }
            }
            return temp;
        }

        public static bool isPalindrome(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                    return false;
            }
            return true;
            //return s.SequenceEqual(s.Reverse()); 比較慢
        }

        #endregion

        #region --- 11 --- 盛最多水的容器
        public static int MaxArea(int[] height)
        {
            int Max = 1;

            if (height.Length == 1)
            {
                return 0;
            }

            int j = 0;
            int k = height.Length - 1;
            while (j < k)
            {
                int temp = Math.Min(height[j], height[k]) * (k - j);
                if (temp > Max)
                    Max = temp;
                if (Math.Min(height[j], height[k]) == height[j])
                {
                    j++;
                }
                else
                {
                    k--;
                }
            }
            return Max;
        }
        #endregion

        #region --- 12 --- 整數轉羅馬數字
        /*字符          数值
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000
        */
        //55 5
        public static string IntToRoman(int num)
        {
            StringBuilder Roman = new StringBuilder();
            Dictionary<int, string> map = new Dictionary<int, string>();
            //建立一個map
            map.Add(1000, "M");
            map.Add(900, "CM");
            map.Add(500, "D");
            map.Add(400, "CD");
            map.Add(100, "C");
            map.Add(90, "XC");
            map.Add(50, "L");
            map.Add(40, "XL");
            map.Add(10, "X");
            map.Add(9, "IX");
            map.Add(5, "V");
            map.Add(4, "IV");
            map.Add(1, "I");
            //利用貪婪演算法，每次取最大的
            while (num != 0)
            {
                foreach (var VARIABLE in map)
                {

                    if (num - VARIABLE.Key >= 0)
                    {
                        num -= VARIABLE.Key;
                        Roman.Append(VARIABLE.Value);
                        break;
                    }
                }
            }
            return Roman.ToString();
        }

        #endregion

        #region --- 15 --- 三數之和
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> temp;

            Array.Sort(nums);
            for (int first = 0; first < nums.Length - 2; first++)
            {
                // The numbers of first, second, third should be indexes.
                if (first > 0 && nums[first] == nums[first - 1])
                {
                    continue;
                }
                int second = first + 1;
                int third = nums.Length - 1;
                while (second < third)
                {
                    if (nums[second] == nums[second - 1] && second > first + 1)
                    {
                        second++;
                        continue;
                    }
                    int sum = nums[first] + nums[second] + nums[third];
                    if (sum == 0)
                    {
                        temp = new List<int>
                        {
                            nums[first],
                            nums[second],
                            nums[third]
                        };
                        result.Add(temp);
                        second++;
                        third--;
                    }
                    else if (sum < 0)
                    {
                        second++;
                    }
                    else
                    {
                        third--;
                    }
                }
            }
            return result;
        }
        //public static IList<IList<int>> ThreeSum(int[] nums)
        //{
        //    IList<IList<int>> sumList = new List<IList<int>>();
        //    Array.Sort(nums);
        //    DFS_Three(nums, 0, 0, 0, new List<int>(), sumList);
        //    return sumList;
        //}

        //private static void DFS_Three(int[] nums, int start, int target, int times, IList<int> oneResult, IList<IList<int>> result)
        //{
        //    if (target == 0 && times == 3)
        //    {
        //        result.Add(new List<int>(oneResult));
        //    }
        //    else if (times < 3)
        //    {
        //        for (int i = start; i < nums.Length; i++)
        //        {
        //            times++;
        //            if(times==1 && nums[i] > 0)
        //                return;
        //            oneResult.Add(nums[i]);
        //            DFS_Three(nums, i + 1, target - nums[i], times, oneResult, result);
        //            oneResult.RemoveAt(oneResult.Count - 1);
        //            if (times == 3 && target - nums[i] == 0)
        //            {
        //                times--;
        //                break;
        //            }
        //            times--;
        //            for (; i < nums.Length - 1; i++)
        //            {
        //                if (nums[i] != nums[i + 1])
        //                    break;
        //            }
        //        }
        //    }
        //}
        #endregion

        #region --- 17 --- 電話號碼排列

        public static IList<string> LetterCombinations2(string digits) {
            var ans = new List<string>();
            if(digits.Length == 0) return ans;
            var map = new Dictionary<char,string>();
            map.Add('2',"abc");
            map.Add('3',"def");
            map.Add('4',"ghi");
            map.Add('5',"jkl");
            map.Add('6',"mno");
            map.Add('7',"pqrs");
            map.Add('8',"tuv");
            map.Add('9',"wxyz");
            var temp = new StringBuilder();
            Backtrack(digits,0,map,temp, ans);
            Console.Write(temp);
            return ans;
        }
        public static void Backtrack(string digits,int index,Dictionary<char,string> map,StringBuilder temp, List<string> ans){
            if(index == digits.Length){
                ans.Add(temp.ToString());
                return;
            }
            char digit = digits[index];
            string letters = map[digit];
            int n = letters.Length;
            for(int i = 0;i < n;i++){
                //每次都是在temp的後面加一個字母，直到index == digits.Length 時，就把temp加入ans的字串中
                temp.Append(letters[i]);
                Backtrack(digits,index+1,map,temp, ans);
                //要把temp的最後一個字母刪除，因為要換下一個字母
                temp.Remove(temp.Length-1,1);
            }
        }

        #endregion

        #region --- 22--- 括号生成
        public static IList<string> GenerateParenthesis(int n)
        {
            List<String> list = new List<String>();
            backtrack(list, "", 0, 0, n);
            return list;
        }
        public static void backtrack(List<String> list, String str, int open, int close, int max)
        {

            if (str.Length == max * 2)
            {
                list.Add(str);
                return;
            }

            if (open < max)
                backtrack(list, str + "(", open + 1, close, max);
            if (close < open)
                backtrack(list, str + ")", open, close + 1, max);
        }

        #endregion

        #region --- 26 --- 删除有序数组中的重复项
        public static int RemoveDuplicates(int[] nums)
        {
            List<int> ans = new List<int>();
            foreach (var i in nums)
            {
                if (!ans.Contains(i))
                {
                    ans.Add(i);
                }
            }
            for (int i = 0; i < ans.Count; i++)
            {
                nums[i] = ans[i];
            }
            return ans.Count;
        }
        #endregion

        #region --- 27 --- 移除元素

        public static int RemoveElement(int[] nums, int val)
        {
            //如果是0的話直接回傳
            if (nums.Length == 0)
            {
                return 0;
            }
            Array.Sort(nums);
            int count = nums.Length;
            //如果目標移除的數自是在最後面的話
            if (val == nums[nums.Length - 1])
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    if (nums[i] != val)
                    {
                        return i + 1;
                    }

                    if (i == 0)
                    {
                        return 0;
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                if (nums[i] == val)
                {
                    //如果再換的時候也遇到要移除的數字則直接往前
                    for (int j = count - 1; j > i; j--)
                    {
                        if (nums[j] == val)
                            count--;
                        else
                        {
                            break;
                        }
                    }

                    nums[i] = nums[count - 1];
                    nums[count - 1] = val;
                    count--;
                }

            }
            return count;
        }

        #endregion

        #region --- 29 --- 两数相除
        //不能使用除法
        public static int Divide(int dividend, int divisor)
        {
            if (dividend == 0)
            {
                return 0;
            }
            if (dividend == Int32.MaxValue && divisor == -1)
            {
                return Int32.MaxValue;
            }
            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }
            bool negative;
            negative = (dividend ^ divisor) < 0;//用异或来计算是否符号相异
            long t = Math.Abs((long)dividend);
            long d = Math.Abs((long)divisor);
            int result = 0;
            for (int i = 31; i >= 0; i--)
            {
                if ((t >> i) >= d)
                {//找出足够大的数2^n*divisor
                    result += 1 << i;//将结果加上2^n
                    t -= d << i;//将被除数减去2^n*divisor
                }
            }
            return negative ? -result : result;//符号相异取反
        }

        #endregion

        #region --- 35 --- 搜索插入位置
        public static int SearchInsert(int[] nums, int target)
        {
            if (target < nums[0])
            {
                return 0;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (target <= nums[i])
                {
                    return i;
                }
            }

            return nums.Length;
        }
        #endregion

        #region --- 39 --- 組合總和I

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            if (candidates.Length == 0) return result;
            Array.Sort(candidates);
            DFS(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private static void DFS(int[] candidates, int target, int start, IList<int> oneResult, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(oneResult));
            }
            else if (target > 0)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    oneResult.Add(candidates[i]);
                    DFS(candidates, target - candidates[i], i, oneResult, result);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }

        #endregion

        #region --- 40 --- 組合總和II
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            if (candidates.Length == 0) return result;
            Array.Sort(candidates);
            DFS2(candidates, target, 0, new List<int>(), result);
            result = result.Distinct().ToList();
            return result;
        }

        private static void DFS2(int[] candidates, int target, int start, IList<int> oneResult, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(oneResult));
            }
            else if (target > 0)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    oneResult.Add(candidates[i]);
                    DFS2(candidates, target - candidates[i], i + 1, oneResult, result);
                    oneResult.RemoveAt(oneResult.Count - 1);
                    for (; i < candidates.Length - 1; i++)
                    {
                        if (candidates[i] != candidates[i + 1])
                            break;
                    }
                }
            }
        }

        #endregion

        #region --- 53 --- 最大子序和
        public static int MaxSubArray(int[] nums)
        {
            int Sum = -5;
            int Temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int flag = 0; flag < nums.Length; flag++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (j + flag >= nums.Length)
                        {
                            break;
                        }
                        Temp += nums[j + flag];
                    }
                    if (Temp > Sum)
                    {
                        Sum = Temp;
                    }
                    Temp = 0;
                }
            }
            return Sum;
        }
        //最後解
        public static int MaxSubArray2(int[] nums)
        {
            int max_val = nums[0];
            int tem = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                tem = nums[i] > tem + nums[i] ? nums[i] : tem + nums[i];
                max_val = max_val > tem ? max_val : tem;
            }
            return max_val;
        }
        #endregion

        #region --- 66 --- 加一

        public static int[] PlusOne(int[] digits)
        {
            //沒啥好寫的
            int i = 0;
            for (i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    break;
                }
                digits[i]++;
                if (digits[i] == 10)
                    digits[i] = 0;
            }

            if (i == -1 && digits[0] == 0)
            {
                int[] answer = new int[digits.Length + 1];
                answer[0] = 1;
                return answer;
            }
            return digits;
        }

        #endregion

        #region --- 69 --- Sqrt(x)
        public static int MySqrt(int x)
        {
            int ans = 0;

            ans = (int)Math.Pow(x, 0.5);
            return ans;
        }
        #endregion

        #region --- 70 --- 爬楼梯题
        public static int ClimbStairs(int n)
        {
            decimal ans = 0;
            for (int i = 0; i <= n; i++)
            {
                if ((n - i * 2) >= 0)
                {
                    if (i > n - i * 2)
                    {
                        ans += call(i + n - i * 2, i) / call(n - i * 2, 1);
                    }
                    else
                    {
                        ans += call(i + n - i * 2, n - i * 2) / call(i, 1);
                    }
                }
                else
                {
                    break;
                }
            }
            return 1;
        }
        public static decimal call(int n, int be)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n == be)
            {
                return 1;
            }
            decimal ans = 1;
            for (int i = be + 1; i <= n; i++)
            {
                ans *= i;
            }

            return ans;
        }
        #endregion

        #region --- 94 --- 二叉树的中序遍历
        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while (cur != null || stack.Count() != 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                list.Add(cur.val);
                cur = cur.right;
            }
            return list;
        }
        #endregion

        #region --- 121 --- 买卖股票的最佳时机
        public static int MaxProfit(int[] prices)
        {
            int Maxprice = 0;
            int left = 0, right = 1;
            int leftprice = 0;
            if (prices.Length == 1)
            {
                return 0;
            }
            while (right <= prices.Length - 1)
            {
                int temp = prices[right] - prices[left];
                if (temp > Maxprice)
                {
                    Maxprice = temp;
                }
                if (prices[left] > prices[right])
                {
                    left = right;
                }
                right++;
            }

            return Maxprice;
        }
        #endregion

        #region --- 136--- 只出现一次的数字
        public static int SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            int signal = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    signal += nums[i];
                }
                else
                {
                    signal -= nums[i];
                }
            }
            return signal;
        }
        #endregion

        #region --- 141--- 环形链表
        public bool HasCycle(ListNode head)
        {
            List<ListNode> Goin = new List<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                if (Goin.Contains(cur))
                {
                    return true;
                }
                Goin.Add(cur);
                cur = cur.next;
            }

            return false;
        }
        #endregion

        #region --- 155 --- 最小栈 (爛解)
        public class MinStack
        {

            LinkedList<int> linkedList = new LinkedList<int>();
            public MinStack()
            {
                linkedList = new LinkedList<int>();
            }

            public void Push(int val)
            {
                linkedList.AddLast(val);
            }

            public void Pop()
            {
                linkedList.RemoveLast();
            }

            public int Top()
            {
                return linkedList.Last.Value;
            }

            public int GetMin()
            {
                return linkedList.Min();
            }
        }
        #endregion

        #region --- 169 --- 多数元素
        public static int MajorityElement(int[] nums)
        {
            int count = 0, number = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (number == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                    if (i == 0 || count == -1)
                    {
                        count = 0;
                        number = nums[i];
                    }
                }
            }

            return number;
        }
        #endregion

        #region --- 202 --- 快樂數

        public static bool IsHappy(int n)
        {
            //把出現過的值記錄在List中，如果遇到一樣的則回傳false值到n==1
            List<int> num = new List<int>();
            num.Add(n);
            while (n != 1)
            {
                int temp = 0;
                for (int i = n; i > 0; i /= 10)
                {
                    temp += (i % 10) * (i % 10);
                }

                if (num.Contains(temp))
                {
                    return false;
                }
                num.Add(temp);
                n = temp;
            }
            return true;
        }

        #endregion

        #region --- 203 --- 移除链表元素
        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }
            // 已经为null，提前退出
            if (head == null)
            {
                return head;
            }
            // 已确定当前head.val != val
            ListNode pre = head;
            ListNode cur = head.next;
            while (cur != null)
            {
                if (cur.val == val)
                {
                    pre.next = cur.next;
                }
                else
                {
                    pre = cur;
                }
                cur = cur.next;
            }
            return head;
        }

        #endregion

        #region --- 205 --- 同構字串符
        //爛到哭 25%
        public static bool IsIsomorphic(string s, string t)
        {
            Hashtable sht = new Hashtable();
            Hashtable tht = new Hashtable();
            int scount = 0, tcount = 0;
            //如果長度不一樣值接回傳false
            if (s.Length != t.Length)
                return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!sht.ContainsKey(s[i].ToString()))
                {
                    sht.Add(s[i].ToString(), scount);
                    scount++;
                }
                if (!tht.ContainsKey(t[i].ToString()))
                {
                    tht.Add(t[i].ToString(), tcount);
                    tcount++;
                }
                if (Convert.ToInt32(sht[s[i].ToString()]) != Convert.ToInt32(tht[t[i].ToString()]))
                    return false;
            }
            return true;
        }
        //public static bool IsIsomorphic(string s, string t)
        //{
        //    Dictionary<string, int> sht = new Dictionary<string, int>();
        //    Dictionary<string, int> tht = new Dictionary<string, int>();
        //    int scount = 0, tcount = 0;
        //    if (s.Length != t.Length)
        //        return false;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (!sht.ContainsKey(s[i].ToString()))
        //            sht[s[i].ToString()] = 0;
        //        if (!tht.ContainsKey(t[i].ToString()))
        //            tht[t[i].ToString()] = 0;
        //        sht[s[i].ToString()]++;
        //        tht[t[i].ToString()]++;
        //        if (sht[s[i].ToString()] != tht[t[i].ToString()])
        //            return false;
        //    }
        //    return true;
        //}
        #endregion

        #region --- 206--- 反转链表
        public static ListNode ReverseList(ListNode head)
        {
            if (head != null && head.next != null)
            {
                ListNode cur = head, pre = head, next = cur.next;
                while (cur.next != null)
                {
                    if (pre == cur)
                        pre.next = null;
                    else
                        cur.next = pre;
                    pre = cur;
                    cur = next;
                    next = next.next;
                }
                cur.next = pre;
                return cur;
            }
            else
            {
                return head;
            }
        }
        #endregion

        #region --- 216 --- 組合總和III
        public static IList<IList<int>> CombinationSum3(int number, int target)
        {
            //建立一個使用的array
            int[] candidates = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = new List<IList<int>>();
            if (candidates.Length == 0) return result;
            //先做排序
            Array.Sort(candidates);
            DFS3(candidates, target, 0, new List<int>(), result, number);
            //將重複的元素刪除
            result = result.Distinct().ToList();
            return result;
        }

        private static void DFS3(int[] candidates, int target, int start, IList<int> oneResult, IList<IList<int>> result, int number)
        {
            //如果達到目標和是在限制的長度的話 加入到Result的List中
            if (target == 0 && oneResult.Count == number)
            {
                result.Add(new List<int>(oneResult));
            }
            else if (target > 0)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    oneResult.Add(candidates[i]);
                    DFS3(candidates, target - candidates[i], i + 1, oneResult, result, number);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }
        #endregion

        #region --- 231 --- 2的幂
        public static bool IsPowerOfTwo(int n)
        {
            if (n == 1)
                return true;
            if (n <= 0)
                return false;
            while (n > 0)
            {
                if (n % 2 == 1)
                    return false;
                if (n / 2 == 1 && n % 2 == 0)
                    break;
                if (n / 2 == 1 && n % 2 == 1)
                    return false;
                n /= 2;
            }
            return true;
        }


        #endregion

        #region --- 283 --- 移動零
        //將0移到最後面
        public static void MoveZeroes(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count++;
            }

            var result = from num in nums where num != 0 select num;
            int flag = 0;
            foreach (var VARIABLE in result)
            {
                nums[flag] = VARIABLE;
                flag++;
            }
            for (; flag < nums.Length; flag++)
            {
                nums[flag] = 0;
            }
        }
        #endregion

        #region --- 290 --- 單詞規律
        public static bool WordPattern(string pattern, string s)
        {
            //建立一個hashtable來記錄pattern和存入的值，如果一樣的pattern不同值則false，同樣的值不一樣的pattern則false
            Hashtable ht = new Hashtable();
            int count = 0;
            string[] sArray = s.Split(' ');
            if (pattern.Length != sArray.Length)
            {
                return false;
            }
            foreach (var s1 in sArray)
            {
                if (ht.Contains(pattern[count].ToString()))
                {
                    if (ht[pattern[count].ToString()].Equals(s1))
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (ht.ContainsValue(s1))
                {
                    return false;
                }
                ht.Add(pattern[count].ToString(), s1);
                count++;
            }
            //if (ht.Values.Distinct().Count() != ht.Values.Count)
            //    return false;
            return true;
        }
        #endregion

        #region --- 292 ---  Nim 游戏

        public static bool CanWinNim(int n)
        {
            //巴甚博奕，n%(m+1)!=0時，先手總是會贏的
            return n % 4 != 0;
        }

        #endregion

        #region --- 326 --- 3 的幂
        public static bool IsPowerOfThree(int n)
        {
            if (n == 1)
                return true;
            if (n <= 0 || n == 2)
                return false;

            while (n > 0)
            {
                if (n % 3 != 0)
                    return false;
                if (n / 3 == 1 && n % 3 == 0)
                    break;
                if (n / 3 == 1 && n % 3 != 0)
                    return false;
                n /= 3;
            }
            return true;
        }
        #endregion

        #region --- 338 --- 比特位计数
        public static int[] CountBits(int n)
        {
            int[] CountNum = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                int Count = 0;
                string temp = Convert.ToString(i, 2);
                int lenght = temp.Length - 1;
                while (lenght >= 0)
                {
                    if (temp[lenght] == '1')
                        Count++;
                    lenght -= 1;
                }
                CountNum[i] = Count;
            }

            return CountNum;
        }

        #endregion

        #region --- 448 --- 找到所有数组中消失的数字
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> list = new List<int>();
            int[] q = nums.Distinct().ToArray();
            Array.Sort(q);

            for (int i = 1, count = 0; i <= nums.Length; i++)
            {
                if (count < q.Length)
                {
                    if (i == q[count])
                    {
                        count++;
                        continue;
                    }
                }
                list.Add(i);
            }
            return list;
        }
        #endregion

        #region --- 461 --- 漢銘距離
        //二進位時，兩個的距離直接取XOR
        public static int HammingDistance(int x, int y)
        {
            int difference = 0;
            foreach (var VARIABLE in Convert.ToString(x ^ y, 2))
            {
                if (VARIABLE == '1')
                    difference++;
            }
            return difference;
        }
        #endregion

        #region --- 1207 --- 独一无二的出现次数

        public static bool UniqueOccurrences(int[] arr)
        {
            //利用Dictionary記錄所有出現的數字
            Dictionary<string, int> table = new Dictionary<string, int>();
            foreach (var i in arr)
            {
                table[i.ToString()] = 0;
            }
            //把遇到的數字都+1
            foreach (var i in arr)
            {
                table[i.ToString()] += 1;
            }
            //把Value中重複的去掉，如果和原本一樣的就沒有重複，若無則否。
            if (table.Values.Distinct().Count() != table.Values.Count)
                return false;

            return true;
        }

        #endregion
        
    }

}
