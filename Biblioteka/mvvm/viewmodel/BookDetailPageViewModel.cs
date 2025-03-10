using Biblioteka.mvvm.model;
using Biblioteka.mvvm.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    
    public class BookDetailPageViewModel:BaseVM
    {
        private FakeDB connect;
        private Book _book;

        public Book SelectedBook
        {
            get { return _book; }
            set {
                _book = value;
                Signal();
            }
        }

        //public CommandVM BackClick {  get; set; }
        public CommandVM UpdateBook {  get; set; }
        public CommandVM DeleteBook { get; set; }

        public BookDetailPageViewModel()
        {

            connect = FakeDB.Instance;
            if (connect.SelectedBook!=null) SelectedBook = connect.SelectedBook;
                DeleteBook = new CommandVM(async ()=>
            {
                await connect.RemoveBookByIdAsync(SelectedBook.Id);
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            UpdateBook = new CommandVM(async () =>
            {
                //передача данных в AddBookPage через бд
                if (SelectedBook != null)
                {
                    connect.SelectedBook = SelectedBook;
                    SelectedBook = null;
                    await Application.Current.MainPage.Navigation.PushAsync(new AddBookPage());
                }
            });
        }

    }
}
