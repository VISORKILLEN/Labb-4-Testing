using Labb_4_Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Librarytesting
{
    [TestClass]
    public sealed class LibraryTests
    {
        private LibrarySystem? _library;

        [TestInitialize]
        public void Setup()
        {
            _library = new LibrarySystem();
        }

        //AddBook Test

        [TestMethod]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var book = new Book("Test Book", "Test Author", "111", 2024);

            bool result = _library!.AddBook(book);

            Assert.IsTrue(result);
        }

        //RemoveBook Test
        [TestMethod]
        public void RemoveBook_ShouldRemoveBookFromLibrary()
        {
            var book = new Book("Test Book", "Test Author", "111", 2024);
            _library!.AddBook(book);

            bool result = _library.RemoveBook("111");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveBook_ShouldReturnFalseIfBookNotFound()
        {
            bool result = _library!.RemoveBook("doesnotxist");
            Assert.IsFalse(result);
        }

        //SearchByISBN Test
        [TestMethod]
        public void SearchByISBN_ShouldReturnBookIfFound()
        {
            var result = _library.SearchByISBN("111");
            Assert.IsNotNull(result);
        }
    }
}
