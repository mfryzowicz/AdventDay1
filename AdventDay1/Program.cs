// See https://aka.ms/new-console-template for more information

using AdventDay1;

Console.WriteLine("Starting processor!");

List<string> test = new()
{
    "two1nine",
    "abcone2threexyz",
    "xtwone3four",
    "4nineeightseven2",
    "zoneight234",
    "7pqrstsixteen"
};

TrebuchetCalibrator calibrator = new();

var input = File.ReadAllLines("/Users/mfryzowicz/Documents/Repos/AdventOfCode/Day1/AdventDay1/AdventDay1/input.txt").ToList();

await calibrator.CalibrationExtractorRevised(input);

Console.WriteLine("Ending processor!");