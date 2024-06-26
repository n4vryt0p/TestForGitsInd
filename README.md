# TestForGitsInd

- Developed using Visual Studio 2022
- Using .Net core 8.0
- Console application
- Docker ready

Answer for #2
```
var brackets = new[] { [ '{', '}' ], [ '[', ']' ], new[] { '(', ')' }  };
for (var j = 0; j < brackets.Length; j++)
{
    //Using LINQ to filters out the the opening and the closing brackets
    var b = brackestString.Where(c => c == brackets[j][0] || c == brackets[j][1])
        .Select((c, ii) => (c == brackets[j][0]) == (ii % 2 == 0))
        .ToArray();

    //Then checks that there are only alternating brackets (starting with the opening), an even number
    var isCool = b.Length % 2 == 0 && b.All(ii => ii)
}
```
