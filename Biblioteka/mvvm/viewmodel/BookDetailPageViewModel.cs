﻿using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    [QueryProperty(nameof(SelectedBook), "SelectedBook")]
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

            //BackClick = new CommandVM(async()=>
            //{
            //    await Shell.Current.GoToAsync("MainPage");
            //});
            DeleteBook = new CommandVM(async ()=>
            {
                await connect.RemoveBookByIdAsync(SelectedBook.Id);
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            UpdateBook = new CommandVM(async () =>
            {
                //передача данных в AddBookPage
                if (SelectedBook != null)
                {
                    var navigationParameter = new ShellNavigationQueryParameters
                    {
                        { "UpdatingBookId", SelectedBook.Id }
                    };
                    await Shell.Current.GoToAsync("AddBookPage", navigationParameter);
                }
            });
        }

    }
}
