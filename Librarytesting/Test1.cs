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

        //Borrow book tests
        [TestMethod]
        public void BorrowBook_ShouldReturnBookIfFound()
        {
            bool result = _library.BorrowBook("111");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BorrowBook_AlreadyBorrowed_ShouldReturnFalse()
        {
            _library.BorrowBook("111");

            bool result = _library.BorrowBook("111");

            Assert.IsFalse(result);
        }

        //Return Books tests
        [TestMethod]
        public void ReturnBook_ShouldReturnTrue()
        {
            _library.BorrowBook("9780451524935");

            bool result = _library.ReturnBook("9780451524935");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReturnBook_NotBorrowed_ShouldReturnFalse()
        {
            bool result = _library.ReturnBook("9780451524935");

            Assert.IsFalse(result);
        }
    }
}
