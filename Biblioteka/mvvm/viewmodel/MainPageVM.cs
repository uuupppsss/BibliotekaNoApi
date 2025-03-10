using Biblioteka.mvvm.model;
using Biblioteka.mvvm.view;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class MainPageVM:BaseVM
    {
        //Коллекция всех книг
        private FakeDB connect;
        private List<Book> _books;
        public List<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                Signal();
            }
        }

        // Коллекция популярных книг
        private List<Book> _popularBooks;
        public List<Book> PopularBooks
        {
            get => _popularBooks;
            set
            {
                _popularBooks = value;
                Signal();
            }
        }

        // Выбранная книга
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set { 
                _selectedBook = value;
                Signal();
            }
        }

        public CommandVM AddBook { get; set; }
        public CommandVM Login { get; set; }
        public CommandVM BooksView { get; set; }


        public MainPageVM()
        {
            connect = FakeDB.Instance;
            connect.BooksListChanged += LoadBooks;
            LoadBooks();
            AddBook = new CommandVM(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new AddBookPage());
            });

            Login=new CommandVM(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            });

            BooksView = new CommandVM(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new BooksPage());
            });
        }

        private async void LoadBooks()
        {
            Books = await connect.GetBooksAsync();
            PopularBooks = Books.Where(b => b.IsPopular).ToList();
        }
    }
}
