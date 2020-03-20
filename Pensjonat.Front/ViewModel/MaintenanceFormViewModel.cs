using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pensjonat.Data;

namespace Pensjonat.UI.ViewModel
{
   public class MaintenanceFormViewModel : INotifyPropertyChanged
    {
        public AdditionalMethods model = new AdditionalMethods();
        public ReservationBook resbook = new ReservationBook();

        public ICommand SaveCommand { get; private set; }
        public MaintenanceFormViewModel()
        {
            Task.Run(() => Init());
        }


        public MaintenanceFormViewModel(bool init)
        {
            // Konstruktor uzywany w testach jednostkowych
            if (init)
                Init();
        }

        //public List<Guest>PensionGuests { get; set; }
        //public List<Room>PensionRooms { get; set; }
        public List<string> listaroboczab = new List<string>();// lista do której dodajemy "Guests" i "Roms" jako stringi tylko do wyświetlenia
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            /*
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            */
            // C# 6.0:
            this.PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        // lista do tego zbindwoane jest to co pokazuje combobox -  w tym wypadku "Guest" i "Roms"
        public IEnumerable<string> lista
        {
            get
            { 
                return listaroboczab;
            }
            set
            {

            }
        }

        // do tego zbindowane jest to co pokaże się po wybraniu wartości z combobox
        private string listawybrana;
        public string Listawybrana
        {
            get
            {
                return listawybrana;
                
            }
            set
            {
                this.listawybrana = value;
                this.OnPropertyChanged();
                this.OdswiezShowedList(); // odpwiada za odświerzenie wartości


            }
        }
        
        

        //metoda inicjująca wartości w comboboxie i przykładowe dane
        public void Init()
        {

            listaroboczab.Add("Rooms");
            listaroboczab.Add("Guests");
           
            ExampleData();
            //RefreshData();

            this.SaveCommand = new RelayCommand(
                action => this.AddButtonReservation());
                

        }

        /*public void RefreshData()
        {
            PensionGuests = resbook.GuestList;
            PensionRooms = resbook.RoomList;
        }*/

        //przykładowa dane
        public void ExampleData()
        {
            model.AddGuest("Marcin", "Wolkowicz", "Polish");
            model.AddGuest("Łucja", "Wolkowicz", "Polish");
            model.AddGuest("Franek", "Wolkowicz", "Polish");
            model.AddRooms(RoomType.doublebed);
            model.AddRooms(RoomType.doublebed);
            model.AddRooms(RoomType.single);

        }

      
        // metoda interfejs do której zbindowane są dane glówne
        public IEnumerable<Object> showedList;
        public IEnumerable<Object> ShowedList
        {
            get
            {
                if (Listawybrana == "Guests")
                {
                    return model.DisplayGuests();
                }
                else
                {
                    return model.DisplayRooms();
                }
            }
            set
            {
                if (Listawybrana == "Guests")
                {
                    this.showedList = model.DisplayGuests();
                }
                else
                {
                    this.showedList = model.DisplayRooms();
                }
                    
                this.OnPropertyChanged();
                
            }
        }

        public void OdswiezShowedList()
        {
            this.ShowedList = null;
            this.ShowedList = model.DisplayGuests();
        }
        //pobiera z textboxa wartość, w tym wypadku id klienta
        private int idRobocze;
        public int IdRobocze
        {
            get { return idRobocze; }
            set
            {
                idRobocze = value;
                this.OnPropertyChanged();
            }

        }
        //dodaje rezerwację
        public void AddButtonReservation()
        {
            model.AddReservation(IdRobocze, RoomType.doublebed);
            this.OnPropertyChanged();
            this.OdswiezShowedList();
        }
    }
}
