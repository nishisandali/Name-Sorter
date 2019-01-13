using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System.IO;
using System.Collections.Generic;

namespace name_sorterTests
{
    [TestClass]
    public class SortNameTests
    {
        string[] names = File.ReadAllLines(@"unsorted-names-list.txt");

        // Testing GetListofNames Method 
        [TestMethod]
        public void GetListofFullNamesTests()
        {
            List<FullName> TestNameList = SortName.GetListofFullNames(names);

            Assert.IsNotNull(TestNameList);

        }

        // Testing WriteToFile Method
        [TestMethod]
        public void WriteToFileTests()
        {
            SortName.WriteToFile(names);

            string[] testsortednames = File.ReadAllLines(@"sorted-names-list.txt");

            Assert.IsNotNull(testsortednames);
        }
    }
}
