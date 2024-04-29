using AssembyBrowser.AssemblyBrowser;
using AssembyBrowser.Models;
using System.Reflection;

namespace AssemblyBrowserTests
{
    public class BrowserTests
    {
        AssemblyBrowserCore browser = new();
      

        [Fact]
        public void SmokeReadCurrentAssembly()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            browser.BrowseAssembly(assembly);
            var namespaces = browser.Convert();
            Assert.NotNull(namespaces);
            Assert.Equal(4, namespaces.Count());
        }

        [Fact]
        public void CheckNamespaces()
        {
            string assembly = Assembly.GetExecutingAssembly().Location;
            browser.BrowseAssembly(assembly);
            var namespaces = browser.Convert().ToList();

            //Assert.True(namespaces.Contains(, "Unable to find type Foo");
            //Assert.True(namesOfTypes.Contains("Boo"), "Unable to find type Boo");
        }

        //[Fact]
        //public void TestClassWithPrivateMethods()
        //{
        //    var types = assembly!.Members.Select(n => n.Types).SelectMany(t => t);
        //    var boo = types.FirstOrDefault(t => t.Name.Equals("Boo"));

        //    Assert.NotNull(boo);
        //    Assert.AreEqual(Boo.Amount, boo!.Members.Count, $"Amount of members in Boo is {boo!.Members.Count}");

        //    var modifiers = new string[] { "private", "protected", "private protected", "" };
        //    var privateMembers = boo!.Members.Where(m => !m.Modificator.Contains("static"));
        //    foreach (var member in privateMembers)
        //        Assert.Contains(member.Modificator.Trim(), modifiers, $"Some field is not private: {member.ToString()}");
        //}

    }
}