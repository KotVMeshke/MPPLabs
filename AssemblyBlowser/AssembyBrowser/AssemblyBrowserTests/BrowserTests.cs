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

            Assert.NotNull(namespaces);
            Assert.Equal(4, namespaces.Count());
            Assert.NotNull(namespaces[0]);
        }

        

    }
}