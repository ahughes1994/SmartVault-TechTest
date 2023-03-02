using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FizzBuzz.Twisted
{
    public class TwistedFizzBuzz : ITwistedFizzBuzz
    {
        /// <summary>
        /// Returns the FizzBuzz output for a custom user range
        /// </summary>
        /// <param name="lowerBound">The inclusive lower bound of the range</param>
        /// <param name="upperBound">The exclusive upper bound of the range</param>
        /// <returns>A newline separated string of the basic FizzBuzz results</returns>
        public string Solve(int lowerBound, int upperBound)
        {
            var strBuilder = new StringBuilder(Math.Abs(upperBound - lowerBound));

            for (var i = lowerBound; i <= upperBound; i++)
            {
                strBuilder.AppendLine(
                    i % 3 == 0
                        ? (i % 5 == 0
                            ? "FizzBuzz"
                            : "Fizz")
                        : (i % 5 == 0
                            ? "Buzz"
                            : i.ToString()));
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Returns a custom output based on user chosen tokens following a FizzBuzz approach for a custom user range
        /// </summary>
        /// <param name="tokens">The custom numbers to be used with their respective tokens</param>
        /// <param name="lowerBound">The inclusive lower bound of the range</param>
        /// <param name="upperBound">The exclusive upper bound of the range</param>
        /// <returns>A newline separated string of the custom 'FizzBuzz' results</returns>
        public string Solve(Dictionary<int, string> tokens, int lowerBound, int upperBound)
        {
            var strBuilder = new StringBuilder(Math.Abs(upperBound - lowerBound));

            for (var i = lowerBound; i <= upperBound; i++)
            {
                var res = tokens.Where(x => i % x.Key == 0);

                if (res.Count() == 0)
                    strBuilder.AppendLine(i.ToString());
                else
                    strBuilder.AppendLine(string.Join(string.Empty, res.Select(x => x.Value)));
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Returns the FizzBuzz output for a custom, non-sequential set of numbers
        /// </summary>
        /// <param name="values">An array of the numbers to be used for FizzBuzz</param>
        /// <returns>A newline separated string of the basic FizzBuzz results</returns>
        public string Solve(params int[] values)
        {
            var strBuilder = new StringBuilder(values.Length);

            foreach (var v in values)
            {
                strBuilder.AppendLine(
                    v % 3 == 0
                        ? (v % 5 == 0
                            ? "FizzBuzz"
                            : "Fizz")
                        : (v % 5 == 0
                            ? "Buzz"
                            : v.ToString()));
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Returns a custom output based on user chosen tokens following a FizzBuzz approach for a custom, non-sequential set of numbers
        /// </summary>
        /// <param name="tokens">The custom numbers to be used with their respective tokens</param>
        /// <param name="values">An array of the numbers to be used for FizzBuzz</param>
        /// <returns>A newline separated string of the custom 'FizzBuzz' results</returns>
        public string Solve(Dictionary<int, string> tokens, params int[] values)
        {
            var strBuilder = new StringBuilder(values.Length);

            foreach (var v in values)
            {
                var res = tokens.Where(x => v % x.Key == 0);

                if (res.Count() == 0)
                    strBuilder.AppendLine(v.ToString());
                else
                    strBuilder.AppendLine(string.Join(string.Empty, res.Select(x => x.Value)));
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Returns a custom output based on a token generated at 'GET https://rich-red-cocoon-veil.cyclic.app/random'
        /// </summary>
        /// <param name="tokenJson">The JSON for the token to be used</param>
        /// <param name="lowerBound">The inclusive lower bound of the range</param>
        /// <param name="upperBound">The exclusive upper bound of the range</param>
        /// <returns>A newline separated string of custom 'FizzBuzz' results</returns>
        public string Solve(string tokenJson, int lowerBound, int upperBound)
        {
            var tokens = JsonConvert.DeserializeObject<List<ApiToken>>(tokenJson);
            var strBuilder = new StringBuilder(Math.Abs(upperBound - lowerBound));

            for (var i = lowerBound; i < upperBound; i++)
            {
                var res = tokens?.Where(x => i % x.Multiple == 0);

                if (res.Count() == 0)
                    strBuilder.AppendLine(i.ToString());
                else
                    strBuilder.AppendLine(string.Join(string.Empty, res.Select(x => x.Word)));
            }

            return strBuilder.ToString();
        }

        public class ApiToken
        {
            public int Multiple { get; set; } = 0;

            public string Word { get; set; } = string.Empty;
        }
    }
}