# C#

## 기초

### 문자열

- 변수 선언 및 출력

```c#
Console.WriteLine("one");
string two = "two";
Console.WriteLine(two);
// 문자열 보간(string interpolation: C# 6이상부터 사용가능)
Console.WriteLine($"one {two}" + " three");
/*
one
two
one two three
*/
```

- 문자열 작업 - 길이 출력

```c#
string firstFriend = "Maria";
string secondFriend = "Sage";
Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");

Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");
/*
My friends are Maria and Sage
The name Maria has 5 letters.
The name Sage has 4 letters.
*/
```

- 문자열 작업 - 공백 제거

```c#
string greeting = "      Hello World!       ";
Console.WriteLine($"[{greeting}]");
// 앞 공백 제거
Console.WriteLine($"[{greeting.TrimStart()}]");
// 뒷 공백 제거
Console.WriteLine($"[{greeting.TrimEnd()}]");
// 공백 제거
Console.WriteLine($"[{greeting.Trim()}]");
/*
[      Hello World!       ]
[Hello World!       ]
[      Hello World!]
[Hello World!]
*/
```

- 문자열 작업 - 문자열 치환

```c#
string sayHello = "Hello World!";
Console.WriteLine(sayHello);
sayHello = sayHello.Replace("Hello", "Greetings");
Console.WriteLine(sayHello);
/*
Hello World!
Greetings World!
*/
```

- 문자열 작업 - 대/소문자

```c#
string sayHello = "Hello World!";
Console.WriteLine(sayHello.ToUpper());
Console.WriteLine(sayHello.ToLower());
/*
HELLO WORLD!
hello world!
*/
```

- 검색

```c#
string songLyrics = "You say goodbye, and I say hello";
Console.WriteLine(songLyrics.Contains("goodbye"));
Console.WriteLine(songLyrics.Contains("greetings"));

Console.WriteLine(songLyrics.StartsWith("You"));
Console.WriteLine(songLyrics.StartsWith("goodbye"));

Console.WriteLine(songLyrics.EndsWith("hello"));
Console.WriteLine(songLyrics.EndsWith("goodbye"));
/*
True
False
True
False
True
False
*/
```



### List

- 목록 만들기

```c#
var names = new List<string> { "<H>", "E", "L", "O" };
foreach (var name in names)
{
  Console.WriteLine($"Hello {name.ToUpper()}!");
}


Console.WriteLine();
names.Add("L");
names.Remove("O");
foreach (var name in names)
{
  Console.Write($"{name.ToUpper()}");
}
/*
Hello <H>!
Hello E!
Hello L!
Hello O!

<H>ELL
*/
```

- 출력

```c#

```

- 출력

```c#

```

- 출력

```c#

```

- 출력

```c#

```

- 출력

```c#

```

### ㅁㄴㅇ

- 출력

```c#

```

- 출력

```c#

```

- 출력

```c#

```

