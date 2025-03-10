using Biblioteka.mvvm.model;
using Biblioteka.mvvm.viewmodel;

namespace Biblioteka.mvvm.view;

public partial class AddBookPage : ContentPage
{
    public AddBookPage()
    {
        InitializeComponent();
        BindingContext = new AddBookViewModel();
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        PagesCountLabel.Text = $"{e.NewValue:F0} �������";
    }
    //private readonly FakeDB _database;
    //private readonly Book _originalBookData; // �������� ������ ��� ��������������
    //private readonly Book _bookToEdit;

    //public AddBookPage(FakeDB database, Book bookToEdit = null)
    //{
    //    InitializeComponent();
    //    _database = database;
    //    _bookToEdit = bookToEdit;

    //    if (_bookToEdit != null)
    //    {
    //        // ��������� �������� ������ ��� ������ ��������������
    //        _originalBookData = new Book
    //        {
    //            Title = _bookToEdit.Title,
    //            Author = _bookToEdit.Author,
    //            Genre = _bookToEdit.Genre,
    //            PageCount = _bookToEdit.PageCount,
    //            PublishDate = _bookToEdit.PublishDate
    //        };

    //        // ��������� ���� ���������� ��� ��������������
    //        TitleEntry.Text = _bookToEdit.Title;
    //        AuthorEntry.Text = _bookToEdit.Author;
    //        GenrePicker.SelectedItem = _bookToEdit.Genre;
    //        PagesSlider.Value = _bookToEdit.PageCount;
    //        PagesLabel.Text = $"{_bookToEdit.PageCount} �������";
    //        PublishDatePicker.Date = _bookToEdit.PublishDate;
    //    }
    //}

    //private async void OnSaveClicked(object sender, EventArgs e)
    //{
    //    if (string.IsNullOrWhiteSpace(TitleEntry.Text) || string.IsNullOrWhiteSpace(AuthorEntry.Text))
    //    {
    //        await DisplayAlert("������", "����������, ��������� ��� ����.", "OK");
    //        return;
    //    }

    //    if (_bookToEdit == null)
    //    {
    //        var newBook = new Book
    //        {
    //            Title = TitleEntry.Text,
    //            Author = AuthorEntry.Text,
    //            Genre = GenrePicker.SelectedItem?.ToString(),
    //            PageCount = (int)PagesSlider.Value,
    //            PublishDate = PublishDatePicker.Date
    //        };

    //        await _database.AddBookAsync(newBook);
    //    }
    //    else
    //    {
    //        _bookToEdit.Title = TitleEntry.Text;
    //        _bookToEdit.Author = AuthorEntry.Text;
    //        _bookToEdit.Genre = GenrePicker.SelectedItem?.ToString();
    //        _bookToEdit.PageCount = (int)PagesSlider.Value;
    //        _bookToEdit.PublishDate = PublishDatePicker.Date;
    //        await _database.EditBookAsync(_bookToEdit);
    //    }

    //    await DisplayAlert("�����", "����� ������� ���������.", "OK");
    //    await Navigation.PopAsync();
    //}

    //// ������ ������ ��������������
    //private async void OnCancelClicked(object sender, EventArgs e)
    //{
    //    if (_bookToEdit != null)
    //    {
    //        // �������������� �������� ������
    //        _bookToEdit.Title = _originalBookData.Title;
    //        _bookToEdit.Author = _originalBookData.Author;
    //        _bookToEdit.Genre = _originalBookData.Genre;
    //        _bookToEdit.PageCount = _originalBookData.PageCount;
    //        _bookToEdit.PublishDate = _originalBookData.PublishDate;
    //    }

    //    await DisplayAlert("������", "��������� ��������.", "OK");
    //    await Navigation.PopAsync();
    //}
    // ���������� ����� � ������� �� MainPage
    //private async void OnSaveClicked(object sender, EventArgs e)
    //{
    //    var newBook = new Book
    //    {
    //        Title = TitleEntry.Text,
    //        Author = AuthorEntry.Text
    //    };

    //    await _database.AddBookAsync(newBook);

    //    await DisplayAlert("�����", "����� ���������!", "OK");
    //    await Shell.Current.GoToAsync("//MainPage");  // ������� �� ������� ��������
    //}

    //// ������ ���������� � ������� �� MainPage
    //private async void OnCancelClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("//MainPage");
    //}
}