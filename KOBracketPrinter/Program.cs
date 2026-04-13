using KOBracketPrinter.Models;
using KOBracketPrinter;

var players = Enumerable.Range(1, 32)
    .Select(i => new Player(i, $"Player {i}", i))
    .ToList();

//var bracket = BracketBuilder.Build(players, "Demo Tournament - 32 Players");
//BracketDemoData.PopulateDummyScores(bracket);

//var outputPdfPath = Path.Combine(AppContext.BaseDirectory, "custom-knockout-32.pdf");
//CustomKnockoutPdfPrinter.Generate(bracket, outputPdfPath);

var printRequestDto = TestDatas.Get32();
var bracket = PrintRequestMapper.Map(printRequestDto);
var outputPdfPath = Path.Combine(AppContext.BaseDirectory, "test-real-knockout.pdf");
CustomKnockoutPdfPrinter.Generate(bracket, outputPdfPath);


Console.WriteLine($"PDF generated: {outputPdfPath}");