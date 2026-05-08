using Labb_4_Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Librarytesting
{
    [TestClass]
    public class LibraryTests
    {
        private LibrarySystem? _library;

        [TestInitialize]
        public void Setup()
        {
            _library = new LibrarySystem();
        }

        // Add book tests

        [TestMethod]
        public void AddBook_ShouldAddBook()
        {
            var book = new Book("Test", "Author", "999", 2024);

            bool result = _library!.AddBook(book);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBook_ShouldReturnFalse_IfDuplicateISBN()
        {
            var book1 = new Book("Book1", "Author1", "999", 2024);
            var book2 = new Book("Book2", "Author2", "999", 2024);

            _library!.AddBook(book1);

            bool result = _library.AddBook(book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddBook_ShouldReturnFalse_IfISBNIsEmpty()
        {
            var book = new Book("Test", "Author", "", 2024);

            bool result = _library!.AddBook(book);

            Assert.IsFalse(result);
        }

        // Remove books tests

        [TestMethod]
        public void RemoveBook_ShouldReturnTrue()
        {
            var book = new Book("Test", "Author", "111", 2024);

            _library!.AddBook(book);

            bool result = _library.RemoveBook("111");
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveBook_ShouldReturnFalse_IfBorrowed()
        {
            var book = new Book("Test", "Author", "222", 2024);

            _library!.AddBook(book);

            _library.BorrowBook("222");

            bool result = _library.RemoveBook("222");

            Assert.IsFalse(result);
        }

        // Search tests

        [TestMethod]
        public void SearchByTitle_ShouldSupportPartialMatch()
        {
            var result = _library!.SearchByTitle("Hob");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void SearchByTitle_ShouldBeCaseInsensitive()
        {
            var result = _library!.SearchByTitle("the hobbit");

            Assert.AreEqual(1, result.Count);
        }

        // Borrow tests

        [TestMethod]
        public void BorrowBook_ShouldReturnTrue()
        {
            bool result = _library!.BorrowBook("9780451524935");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BorrowBook_ShouldReturnFalse_IfAlreadyBorrowed()
        {
            _library!.BorrowBook("9780451524935");

            bool result = _library.BorrowBook("9780451524935");

            Assert.IsFalse(result);
        }

        // Return test

        [TestMethod]
        public void ReturnBook_ShouldResetBorrowDate()
        {
            _library!.BorrowBook("9780451524935");

            _library.ReturnBook("9780451524935");

            var book = _library.SearchByISBN("9780451524935");

            Assert.IsNull(book!.BorrowDate);
        }

        // Late fees test

        [TestMethod]
        public void CalculateLateFee_ShouldCalculateCorrectly()
        {
            decimal fee =
                _library!.CalculateLateFee("9780451524935", 4);

            Assert.AreEqual(2.0m, fee);
        }
    }
}