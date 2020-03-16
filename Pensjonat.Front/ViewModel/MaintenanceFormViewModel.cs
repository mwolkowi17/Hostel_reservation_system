using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pensjonat.Data;

namespace Pensjonat.UI.ViewModel
{
   public class MaintenanceFormViewModel : INotifyPropertyChanged
    {
        public AdditionalMethods model = new AdditionalMethods();
        public ReservationBook resbook = new ReservationBook();

        public MaintenanceFormViewModel()
        {
            Task.Run(() => Init());
        }

        public List<Guest>PensionGuests { get; set; }
        public List<Room>PensionRooms { get; set; }
        public List<string> listaroboczab = new List<string>();
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
                this.OdswiezShowedList();


            }
        }
        
        

      
        public void Init()
        {

            listaroboczab.Add("Rooms");
            listaroboczab.Add("Guests");
           
            ExampleData();
            RefreshData();
        }

        public void RefreshData()
        {
            PensionGuests = resbook.GuestList;
            PensionRooms = resbook.RoomList;
        }
        
        public void ExampleData()
        {
            model.AddGuest("Marcin", "Wolkowicz", "Polish");
            model.AddGuest("Łucja", "Wolkowicz", "Polish");
            model.AddGuest("Franek", "Wolkowicz", "Polish");
            model.AddRooms(RoomType.doublebed);
            model.AddRooms(RoomType.doublebed);
            model.AddRooms(RoomType.single);

        }

      

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
        
        public List<string> ShowInitialList()
        {
            List<string> roboczalista = new List<string>();
            
            roboczalista.Add("Guests");
            roboczalista.Add("Rooms");
            return roboczalista;
        }
    }
}
