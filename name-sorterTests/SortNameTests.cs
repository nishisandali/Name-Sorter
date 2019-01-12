using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System.IO;
using System.Collections.Generic;

namespace name_sorterTests
{
    [TestClass]
    public class SortNameTests
    {
        [TestMethod]
        public void GetListofFullNamesTests()
        {
            string[] names = File.ReadAllLines(@"unsorted-names-list.txt");

            List<FullName> TestNameList = SortName.GetListofFullNames(names);

            Assert.IsNotNull(TestNameList);

        }

        [TestMethod]
        public void ReadAndWriteToFileTests()
        {
            SortName.ReadAndWriteToFile();

            string[] testsortednames = File.ReadAllLines(@"sorted-names-list.txt");

            Assert.IsNotNull(testsortednames);
        }
    }
}
