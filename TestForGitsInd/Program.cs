// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

while (true)
{
    Console.WriteLine("Hello, please choose one of the numbers below");
    Console.WriteLine("1 = Weighted Strings");
    Console.WriteLine("2 = Balanced Brackets");
    Console.WriteLine("3 = Highest Palindrome");
    Console.WriteLine("ctrl + c to exit anytime");
    var choose = Console.ReadLine();

    Console.WriteLine("");
    if (choose == "1")
    { 
        var isGood = WeightedStrings(true);
        while (!isGood)
            isGood = WeightedStrings(isGood);
    }
    else if (choose == "2")
    {
        var isGood = BalancedBrackets(true);
        while (!isGood)
            isGood = BalancedBrackets(isGood);
    }
    else if (choose == "3")
    {
        HighestPalindrome(true);
    }
    else
    {
        Console.WriteLine("No options!");
    }

    Console.Write("Enter to continue");
    Console.ReadLine();
    Console.WriteLine("");
}

bool WeightedStrings(bool trf)
{
    Console.WriteLine(trf
        ? "Hello, please input strings of alphabet only (A-Z)"
        : "Invalid inputs, start over");
    Console.WriteLine("for example aadbggbcccccttt");

    Console.Write("Input strings: ");
    var alphabetSeri = Console.ReadLine();

    Console.WriteLine("");
    var intArr = new List<int>();
    if (!string.IsNullOrEmpty(alphabetSeri))
    {
        var isCool = Regex.IsMatch(alphabetSeri, "^[a-zA-Z]+$");
        if (!isCool)
            return false;
        var currMulti = 2;
        var alphabetArr = alphabetSeri.ToUpper().ToArray();
        for (var i = 0; i < alphabetArr.Length; i++)
        {
            if (i == 0)
                intArr.Add(char.ToUpper(alphabetArr[i]) - 64);
            else if (alphabetArr[i] == alphabetArr[i - 1])
            {
                intArr.Add((char.ToUpper(alphabetArr[i]) - 64) * currMulti);
                currMulti++;
            }
            else
            {
                intArr.Add(char.ToUpper(alphabetArr[i]) - 64);
                currMulti = 2;
            }
        }
    }

    Console.WriteLine("Please input series of numbers only with comma separator");
    Console.WriteLine("for example 12,348,3,4");
    Console.Write("Input numbers: ");
    var arryNumber = Console.ReadLine();

    Console.WriteLine("");
    if (!string.IsNullOrEmpty(arryNumber))
    {
        var isCool = Regex.IsMatch(arryNumber, @"^([0-9]+,?)+$");
        if (!isCool)
        {
            Console.WriteLine("");
            return false;
        }
        var intArr2 = arryNumber.Split(",");
        var strArrResult = intArr2.Select(t => intArr.Contains(Convert.ToInt32(t))).Select(isThere => isThere ? "Yes" : "No").ToList();

        Console.WriteLine($"Results: [ {string.Join(", ", strArrResult)} ]");
    }
    return true;
}

bool BalancedBrackets(bool trf)
{
    Console.WriteLine(trf
        ? "Hello, please input brackets only parentheses '()', square brackets '[]', and/or curly braces '{}'"
        : "Invalid inputs, start over");
    Console.WriteLine("for example {[ ( )] }");

    Console.Write("Input brackets: ");
    var brackestString = Console.ReadLine();

    Console.WriteLine("");
  
    if (!string.IsNullOrEmpty(brackestString))
    {
        //var replace = brackestString.Replace(" ", "");
        //var isCool = Regex.IsMatch(brackestString, @"\{([^}]*)\}|\(([^)]*)\)|\[([^]]*)\]");
        var brackets = new[] { [ '{', '}' ], [ '[', ']' ], new[] { '(', ')' }  };
        for (var j = 0; j < brackets.Length; j++)
        {
            var b = brackestString.Where(c => c == brackets[j][0] || c == brackets[j][1])
                .Select((c, ii) => (c == brackets[j][0]) == (ii % 2 == 0))
                .ToArray();

            var isCool = b.Length % 2 == 0 && b.All(ii => ii);

            if (!isCool)
            {
                Console.WriteLine("Results: NO");
                Console.WriteLine("");
                return true;
            }
        }

        Console.WriteLine("Results: YES");
        Console.WriteLine("");

    }
    return true;
}

bool HighestPalindrome(bool trf)
{
    Console.WriteLine(trf
        ? "Hello, please input palindrome with numbers only"
        : "Invalid inputs, start over");
    Console.WriteLine("for example  932239");

    Console.Write("Input palindrome: ");
    var s = Console.ReadLine();
    Console.WriteLine("");

    Console.Write("Input palindrome: ");
    var kString = Console.ReadLine();
    Console.WriteLine("");
    int.TryParse(kString, out var k);

    if (!string.IsNullOrEmpty(s) && k > 0)
    {
        var highPal = HighestValuePalindrome(s, k);
        Console.WriteLine($"Result: {highPal}");
        Console.WriteLine("");
    }
    return true;
}

static bool IsPalindrome(string value, int i, int j)
{
    //var i = 0;
    //var j = value.Length - 1;
    if (j == 0) j = value.Length - 1;
    var charArray = value.ToCharArray();
    if (j <= i) return true;

    if (charArray[i] == charArray[j])
    {
        i++; j--;
        IsPalindrome(value, i, j);
    }
    else
        return false;

    return true;

    //while (j > i)
    //{
    //    if (charArray[i] == charArray[j])
    //    {
    //        i++; j--;
    //    }
    //    else
    //        return false;
    //}
    //return true;
}

static int DiffPalindrome(char[] stringArray, int i, int j, int n, int diff = 0)
{
    if (i < n / 2) return diff;
    if (stringArray[i] != stringArray[j])
    {
        diff++;
    }
    i++; j--;
    return DiffPalindrome(stringArray, i, j, diff);
}

static string HighestValuePalindrome(string s, int k)
{
    var n = s.Length;
    var lo = 0;
    var hi = n - 1; ;
    var stringArray = s.ToCharArray();
    var diff = DiffPalindrome(stringArray, 0, n-1, n, 0);

    //for (int i = 0, j = n - 1; i < n / 2; i++, j--)
    //{
    //    if (stringArray[i] != stringArray[j])
    //    {
    //        diff++;
    //    }
    //}

    if (diff > k)
    {
        return "-1";
    }

    while (hi >= lo)
    {
        if (k <= 0)
        {
            break;
        }

        if (stringArray[lo] == stringArray[hi])
        {
            if (k > 1 && k - 2 >= diff && stringArray[lo] != '9')
            {
                stringArray[lo] = '9';
                stringArray[hi] = '9';
                k -= 2;
            }
        }
        else
        {
            if (k > 1 && k - 2 >= diff - 1)
            {
                if (stringArray[lo] != '9')
                {
                    stringArray[lo] = '9';
                    k--;
                }
                if (stringArray[hi] != '9')
                {
                    stringArray[hi] = '9';
                    k--;
                }
            }
            else
            {
                if (stringArray[lo] > stringArray[hi])
                {
                    stringArray[hi] = stringArray[lo];
                }
                else
                {
                    stringArray[lo] = stringArray[hi];
                }
                k--;
            }
            diff--;
        }
        if (lo == hi && k > 0)
        {
            stringArray[lo] = '9';
            k--;
        }
        lo++;
        hi--;
    }

    s = new string(stringArray);
    return IsPalindrome(s,0,0) ? s : "-1";
}
