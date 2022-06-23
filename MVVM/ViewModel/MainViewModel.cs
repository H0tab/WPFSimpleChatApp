using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPFSimpleChatApp.Core;
using WPFSimpleChatApp.MVVM.Model;

namespace WPFSimpleChatApp.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        //Commands
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Bob",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/r1mYK7mb.jpg",
                Message = "test",
                Time = DateTime.UtcNow,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bob",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/r1mYK7mb.jpg",
                    Message = "test",
                    Time = DateTime.UtcNow,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });

                Thread.Sleep(1000);
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Cumster",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/taGMUrW.jpeg",
                    Message = "test",
                    Time = DateTime.UtcNow,
                    IsNativeOrigin = true
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Cumster",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/taGMUrW.jpeg",
                Message = "test",
                Time = DateTime.UtcNow,
                IsNativeOrigin = true,
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Bob {i}",
                    ImageSource = "https://i.imgur.com/r1mYK7mb.jpg",
                    Messages = Messages
                });
            }
        }
    }
}
