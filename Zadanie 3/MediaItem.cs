using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Zadanie_3
{

  

    public class MediaItem : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _directorOrAuthor;
        public string DirectorOrAuthor
        {
            get => _directorOrAuthor;
            set
            {
                if (_directorOrAuthor != value)
                {
                    _directorOrAuthor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _publisherOrStudio;
        public string PublisherOrStudio
        {
            get => _publisherOrStudio;
            set
            {
                if (_publisherOrStudio != value)
                {
                    _publisherOrStudio = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _medium;
        public string Medium
        {
            get => _medium;
            set
            {
                if (_medium != value)
                {
                    _medium = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MediaItem _selectedItem;
        public MediaItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private ObservableCollection<MediaItem> _mediaItems;
        public ObservableCollection<MediaItem> MediaItems
        {
            get => _mediaItems;
            set
            {
                if (_mediaItems != value)
                {
                    _mediaItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand ImportCommand { get; }
        public RelayCommand ExportCommand { get; }

        public MainWindowViewModel()
        {
            MediaItems = new ObservableCollection<MediaItem>();
            EditCommand = new RelayCommand(EditItem, CanEditItem);
            DeleteCommand = new RelayCommand(DeleteItem, CanDeleteItem);
        }
      
       
        
        private bool CanEditItem()
        {
            return SelectedItem != null;
        }

        private bool CanDeleteItem()
        {
            return SelectedItem != null;
        }

        private void EditItem()
        {
            // Otwarcie okna edycji szczegółów wybranego elementu
        }

        private void DeleteItem()
        {
            MediaItems.Remove(SelectedItem);
            SelectedItem = null;
        }



        private void AddItem(object parameter)
        {
            var newItem = new MediaItem();
            MediaItems.Add(newItem);

            // Otwarcie nowego okna jak w przypadku Edytuj
            EditItem(newItem);
        }

        private void EditItem(object parameter)
        {
            // Otwarcie okna edycji szczegółów wybranego elementu
        }

        private bool CanEditItem(object parameter)
        {
            return SelectedItem != null;
        }

        private void DeleteItem(object parameter)
        {
            MediaItems.Remove(SelectedItem);
            SelectedItem = null;
        }

        private bool CanDeleteItem(object parameter)
        {
            return SelectedItem != null;
        }

        private void ImportItems(object parameter)
        {
            // Logika importu z pliku
        }

        private void ExportItems(object parameter)
        {
            // Logika eksportu do pliku
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
