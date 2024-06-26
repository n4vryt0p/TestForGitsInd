// See https://aka.ms/new-console-template for more information
while(true)
{
    Console.WriteLine("Hello, please choose one of the numbers below");
    Console.WriteLine("1 = Weighted Strings");
    Console.WriteLine("2 = Weighted Strings");
    Console.WriteLine("3 = Weighted Strings");
    Console.WriteLine("ctrl + c to exit");
    var choose = Console.ReadLine();

    Console.WriteLine("");
    if (choose == "1")
    {
        Console.WriteLine("Hello, please input series of alphabet only (A-Z)");
        Console.WriteLine("for example aabbbbbcccccttt");
        var alphabetSeri = Console.ReadLine();

        Console.WriteLine("");
        var intArr = new List<int>();
        if (!string.IsNullOrEmpty(alphabetSeri))
        {
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

        Console.WriteLine("Please input series of numbers only with comma delimiter");
        Console.WriteLine("for example 12,348,3,4");
        var arryNumber = Console.ReadLine();

        Console.WriteLine("");
        if (!string.IsNullOrEmpty(arryNumber))
        {
            var intArr2 = arryNumber.Split(",");
            var strArrResult = intArr2.Select(t => intArr.Contains(Convert.ToInt32(t))).Select(isThere => isThere ? "Yes" : "No").ToList();

            Console.WriteLine($"Results: [ {string.Join(", ", strArrResult)} ]");
        }


        Console.ReadLine();
    }
    else if (choose == "2")
    {

    }
    else if (choose == "3")
    {

    }
    else
    {
        Console.WriteLine("No options!");
    }
}