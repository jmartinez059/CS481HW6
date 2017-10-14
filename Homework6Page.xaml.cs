using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Homework6
{
	public partial class Homework6Page : ContentPage
	{
		public Homework6Page()
		{
			InitializeComponent();
			PopulatePicker();
			Set_Map_Location(33.13005900000001, -117.16420099999999);
		}

		private void PopulatePicker()
		{
			var personList = new ObservableCollection<Person>()
			{
				new Person() {firstName = "Jason", lastName = "Martinez", address = "305 S.Nevada St, Oceanside, CA 92054",
					lati = 33.1938885, longi = -117.376778},
				new Person() {firstName = "Roger", lastName = "Elmwood", address = "4415 Jill St, Oceanside, CA 92057",
					lati = 33.2459702, longi = -117.3200064},
				new Person() {firstName = "Virginia", lastName = "Longformore", address = "2601 Jefferson St, Carlsbad, CA 92008",
					lati = 33.166077, longi = -117.34831},

			};
			PickerPerson.ItemsSource = personList;
		}

		public void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            var person = (Person)PickerPerson.SelectedItem;
			var longitude = person.longi;
			var latitude = person.lati;
			Set_Map_Location(latitude, longitude);

            var pin = new Pin()
			{
				Position = new Position(latitude, longitude),
				Label = person.firstName,

			};
			MyMap.Pins.Add(pin);
		}

		private void Set_Map_Location(double latitude, double longitude)
		{
			var newLocation = MapSpan.FromCenterAndRadius(new Position(latitude, longitude), Distance.FromMiles(1));
			MyMap.MoveToRegion(newLocation);

        }

        void Handle_PropertyChanged(object sender, System.EventArgs e)
        {
            var mapType = (String)PickerMapType.SelectedItem;
            if(mapType == "Satellite")
            {
                MyMap.MapType = MapType.Satellite;
            }
            if (mapType == "Street")
            {
                MyMap.MapType = MapType.Street;
            }
            else
            {
                MyMap.MapType = MapType.Hybrid;
            }
        }
    }
}