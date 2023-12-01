namespace AdventDay1;

public class TrebuchetCalibrator
{
    private readonly Dictionary<int, string> _numbersSpelledOut = new()
    {
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" }
    };
    
    public async Task<int> CalibrationExtractorRevised(List<string> input)
    {
        List<int> calibrationValues = new();
        
        foreach (var jumble in input)
        {
            if (jumble.Contains("fourfour"))
            {
                int stop = 0;
            }
            
            List<CharPosHolder> strings = new();
            
            foreach (var num in _numbersSpelledOut)
            {
                var start = 0;

                while ((start = jumble.IndexOf(num.Value, start)) != -1)
                {
                    if (jumble.Contains(num.Value))
                    {
                        strings.Add(new CharPosHolder()
                        {
                            CharacterPosition = jumble.IndexOf(num.Value, start),
                            Digit = num.Key
                        });
                    }

                    start ++;
                }
            }

            strings = strings.OrderBy(x => x.CharacterPosition).ToList();
            List<CharPosHolder> characters = new();
            
            foreach (var c in jumble)
            {
                var start = 0;

                while ((start = jumble.IndexOf(c.ToString(), start)) != -1)
                {
                    if (char.IsDigit(c))
                    {
                        var number = int.Parse(c.ToString());
                        characters.Add(new CharPosHolder()
                        {
                            CharacterPosition = jumble.IndexOf(c, start),
                            Digit = number
                        });
                    }

                    start++;
                }
            }

            characters = characters.OrderBy(x => x.CharacterPosition).ToList();

            int firstValue;
            int secondValue;

            if (strings.Count > 0)
            {
                if (strings.First().CharacterPosition < characters.First().CharacterPosition)
                {
                    firstValue = strings.First().Digit;
                }
                else
                {
                    firstValue = characters.First().Digit;
                }

                if (strings.Last().CharacterPosition > characters.Last().CharacterPosition)
                {
                    secondValue = strings.Last().Digit;
                }
                else
                {
                    secondValue = characters.Last().Digit;
                }
            }
            else
            {
                Console.WriteLine("No spelled out numbers");
                firstValue = characters.First().Digit;
                secondValue = characters.Last().Digit;
            }
            
            var parsedVal = int.Parse($"{firstValue}{secondValue}");
            Console.WriteLine(parsedVal);
            calibrationValues.Add(parsedVal);
        }

        var answer = calibrationValues.Sum();
        Console.WriteLine(answer);
        return answer;
    }
    
    public static async Task<int> CalibrationExtractor(List<string> input)
    {
        List<int> calibrationValues = new();
        
        foreach (var jumble in input)
        {
            List<int> stringDigits = new();
            
            foreach (var c in jumble)
            {
                if (char.IsDigit(c))
                {
                    var number = int.Parse(c.ToString());
                    stringDigits.Add(number);
                }
            }

            var parsedVal = int.Parse($"{stringDigits.First()}{stringDigits.Last()}");
            Console.WriteLine(parsedVal);
            calibrationValues.Add(parsedVal);
        }

        var answer = calibrationValues.Sum();
        Console.WriteLine(answer);
        return answer;
    }
}