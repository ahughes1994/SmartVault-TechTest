using FizzBuzz.Twisted;

var twisted = new TwistedFizzBuzz();
var output = string.Empty;

// output = twisted.Solve(-20, 127);
// output = twisted.Solve(-5, 6, 300, 12, 15);
// output = twisted.Solve(new Dictionary<int, string> { { 3, "Buzz" }, { 5, "Fizz" } }, 1, 101);
// output = twisted.Solve("{\"multiple\":19,\"word\":\"series\"}", 1, 101);

output = twisted.Solve(new Dictionary<int, string> { { 5, "Fizz" }, { 9, "Buzz" }, { 27, "Bar" } }, -20, 128);

Console.Write(output);
Console.ReadLine();