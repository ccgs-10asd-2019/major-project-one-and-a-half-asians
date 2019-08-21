using HayStack.Services;
using HayStack.Utility;
using HayStack.ViewModels;

namespace HayStack
{
    public class ContactsViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private BookViewModel _bookVM;
        public BookViewModel BookVM
        {
            get { return _bookVM; }
            set { OnPropertyChanged(ref _bookVM, value); }
        }

        public ContactsViewModel()
        {
            var dataService = new JsonContactDataService();
            var dialogService = new WindowDialogService();

            BookVM = new BookViewModel(dataService, dialogService);
            CurrentView = BookVM;
        }
    }
}
