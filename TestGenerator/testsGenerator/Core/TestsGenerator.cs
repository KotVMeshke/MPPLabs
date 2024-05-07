namespace Core;

public class TestsGenerator
{
    TestsCompiler compiler;
    private string directoryToLoadTests = @"./tests";

    public TestsGenerator(TestTypesEnum compilerType)
    {
        this.compiler = TestsCompilerFactory.Create(compilerType);
    }

    public async Task GenerateAsync(IEnumerable<string> pathsToFiles, string pathToLoad)
    {
        if (!Directory.Exists(pathToLoad))
            Directory.CreateDirectory(pathToLoad);
        directoryToLoadTests = pathToLoad;

        var pipeline = new GenerationPipeline(LoadClassInfoInMemory, GenerateTestClass, LoadToFile);
        foreach (var path in pathsToFiles)
        {
            pipeline.Post(path);
        }
        pipeline.Complete();

        Console.WriteLine("Tests uploaded");
    }

    public void Generate(IEnumerable<string> pathsToFiles, string pathToLoad)
    {
        if (!Directory.Exists(pathToLoad))
            Directory.CreateDirectory(pathToLoad);

        foreach (var path in pathsToFiles)
        {
            _ = ParseFile(path, pathToLoad);
        }
        Console.WriteLine("Tests uploaded");
    }

    private async Task ParseFile(string path, string pathToLoad)
    {
        var items = LoadClassInfoInMemory(path);
        foreach (var item in items)
        {
            GenerateTestClass(item);
            item.PathToGeneratedClass = Path.Combine(pathToLoad, $"{item.ClassName}Tests.cs");
            await LoadToFile(item);
        }
        Console.WriteLine("End of parsing");
    }

    private List<Models.GenerateItem> LoadClassInfoInMemory(string path)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(path));
        var walker = new CustomWalker();
        walker.Visit(syntaxTree.GetRoot());
        System.Console.WriteLine("End of loading");
        return walker.Items;
    }

    private Core.Models.GenerateItem GenerateTestClass(Core.Models.GenerateItem item)
    {
        item.Code = compiler.GenerateCodeByItem(item);
        item.PathToGeneratedClass = Path.Combine(directoryToLoadTests, $"{item.ClassName}Tests.cs");
        Console.WriteLine("End of generation");
        return item;
    }

    private async Task LoadToFile(Core.Models.GenerateItem item)
    {
        if (!string.IsNullOrEmpty(item.PathToGeneratedClass) && item.Code != null)
            await File.WriteAllTextAsync(item.PathToGeneratedClass, item.Code.ToString());
        else
            Console.WriteLine("Path is null");
    }
}
