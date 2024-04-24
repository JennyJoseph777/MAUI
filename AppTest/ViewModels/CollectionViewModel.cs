using AppTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.ViewModels
{
   public class CollectionViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CollectionModel> meals;
        DateTime dt = new DateTime();
        public ObservableCollection<CollectionModel> Meals
        {
            get { return meals; }
            set
            {
                meals = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Meals"));
            }

        }
        /// <summary>
        /// The PDF document stream that is loaded into the instance of the PDF viewer.
        /// </summary>


        /// <summary>
        /// Constructor of the view model class
        /// </summary>
        public CollectionViewModel()
        {

            Meals = new ObservableCollection<CollectionModel>();
            AddData();
        }



        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        private void AddData()
        {

            Meals.Add(new CollectionModel
            {         
                MenuNumber = "Menu I",              
                SoupType = "Carrot and Ginger Soup",       
                MainmenuType = "Garlic & herb roasted crimini mushrooms stuffed in a russet potato with sour cream",               
                SaladType = "Mixed vegetables and prawns with exotic sauces"+
                "\n" +
                "French fries",
                DessertType = "Tiramisu"

            });


            Meals.Add(new CollectionModel
            {
                MenuNumber = "Menu II",
                SoupType = "Creamy Mushroom Soup",
                MainmenuType = "French style trout,basted with a lemon-parsley sauce",
                SaladType = "Fresh salads served on the cold buffet" +
                "\n" +
                "Baked potatos",
                DessertType = "Stracciatella yogurt"

            });

            Meals.Add(new CollectionModel
            {
                MenuNumber = "Menu III",
                SoupType = "Hot and Sour Soup",
                MainmenuType = "Chicken Burger with French Fries",
                SaladType = "Fresh salads served on the cold buffet",
                DessertType = "Chocolate cheese cake bowl with oreo crumbles and whipped cream"

            });

            Meals.Add(new CollectionModel
            {
                MenuNumber = "Menu IV",
                SoupType = "Creamy summer squash",
                MainmenuType = "Burito with minced Beef, Avacado and beans," ,
                SaladType = "Fresh tofu salad with exotic sauces",
                DessertType = "Peach yoghurt"

            });



        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
        public void OnAppearing()
        {    
        }

    }
}
