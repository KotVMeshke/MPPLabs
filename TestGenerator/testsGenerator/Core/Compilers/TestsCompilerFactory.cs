namespace Core.Compilers;

internal static class TestsCompilerFactory
{
  static Lazy<MSTestsCompiler> mstests = new Lazy<MSTestsCompiler>();  

  public static TestsCompiler Create(TestTypesEnum compiler)
  {
    TestsCompiler result;
    switch(compiler)
    {
      case TestTypesEnum.MSTests:
        result = mstests.Value;
        break;
      default:
        throw new ArgumentException("Unknown compiler enum");
    }
    return result;
  }
}
