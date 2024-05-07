using Core;
var generator = new TestsGenerator(Core.Compilers.TestTypesEnum.MSTests);
var currentDir = Directory.GetCurrentDirectory();
var files = new List<string>()
{
  @"../../../Foo.cs", @"../../../Loo.cs"
};

await generator.GenerateAsync(files, @"../../../test");
