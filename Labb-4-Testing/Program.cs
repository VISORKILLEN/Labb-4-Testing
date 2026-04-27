namespace Labb_4_Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibrarySystem library = new LibrarySystem();
            UserInterface.DisplayMenu(library);
        }
    }
}
