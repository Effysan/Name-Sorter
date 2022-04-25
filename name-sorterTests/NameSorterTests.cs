using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorterNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterNS.Tests {

    [TestClass()]
    public class NameSorterTests {

        [TestMethod()]
        public void ConcatName_ValidName1_AreEqual() {

            var nameSorter = new NameSorter();

            var result = nameSorter.ConcatName("a b c");

            Assert.AreEqual("cab", result);

        }

        [TestMethod()]
        public void ConcatName_ValidName2_AreEqual() {

            var nameSorter = new NameSorter();

            var result = nameSorter.ConcatName("a b c d");

            Assert.AreEqual("dabc", result);

        }

        [TestMethod()]
        public void ConcatName_NameTooShort_AreEqual() {
            // Although a single-name name is invalid for the encapsulating program, ConcatName method will still handle it.

            var nameSorter = new NameSorter();

            var result = nameSorter.ConcatName("a");

            Assert.AreEqual("a", result);

        }

        [TestMethod()]
        public void ConcatName_NameTooLong_AreEqual() {
            // Although a single-name name is invalid for the encapsulating program, ConcatName method will still handle it.

            var nameSorter = new NameSorter();

            var result = nameSorter.ConcatName("a b c d e");

            Assert.AreEqual("eabcd", result);

        }

        [TestMethod()]
        public void ConcatName_EmptyString_EmptyString() {

            var nameSorter = new NameSorter();

            var result = nameSorter.ConcatName("");

            Assert.AreEqual("", result);

        }

        [TestMethod()]
        public void ConcatName_UppercaseString_LowercaseString() {

            var nameSorter = new NameSorter();

            var result = nameSorter.ConcatName("A B C D");

            Assert.AreEqual("dabc", result);

        }


        [TestMethod()]
        public void SortNames_ValidNames_SortedNames() {

            var nameSorter = new NameSorter();

            string[] names = { "A B C", "D E F", "A B A", "X Y Z" };
            string[] answer = { "A B A", "A B C", "D E F", "X Y Z" };
            var result = nameSorter.SortNames(names);

            bool valid = true;
            if(result.Length != answer.Length) {
                valid = false;
            }

            for(int i = 0; i < answer.Length; i++) {
                if(result[i] != answer[i]) {
                    valid = false;
                    break;
                }
            }

            if(!valid) {
                Assert.Fail();
            }

        }


    }
}