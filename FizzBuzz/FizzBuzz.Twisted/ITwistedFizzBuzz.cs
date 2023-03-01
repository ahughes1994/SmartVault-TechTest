namespace FizzBuzz.Twisted
{
    public interface ITwistedFizzBuzz
    {
        string Solve(Dictionary<int, string> tokens, int lowerBound, int upperBound);
        string Solve(Dictionary<int, string> tokens, params int[] values);
        string Solve(int lowerBound, int upperBound);
        string Solve(params int[] values);
        string Solve(string tokenJson, int lowerBound, int upperBound);
    }
}