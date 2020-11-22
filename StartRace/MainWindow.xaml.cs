using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartRace
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public abstract class Vehicle
    {
        public int Speed { get; }                           //скорость метров в секунду
        public int ProbabilityPuncturedWheel { get; }       //вероятность прокола колеса
        public bool isPunctured { get; set; }               //факт прокола

        public Vehicle(int _speed, int _probabilityPuncturedWheel)
        {
            Speed = _speed;
            ProbabilityPuncturedWheel = _probabilityPuncturedWheel;
        }
    }

    public class Truck : Vehicle
    {
        public int CargoWeight { get; }                     //вес груза

        public Truck(int _speed, int _probabilityPuncturedWheel, int _cargoWeight) : base (_speed, _probabilityPuncturedWheel)
        {
            CargoWeight = _cargoWeight;
        }
    }

    public class Car : Vehicle
    {
        public int NumberPassengers { get; }                //количество пассажиров

        public Car(int _speed, int _probabilityPuncturedWheel, int _numberPassengers) : base(_speed, _probabilityPuncturedWheel)
        {
            NumberPassengers = _numberPassengers;
        }
    }

    public class Motorcycle : Vehicle
    {
        public bool isSidecar { get; }                      //наличие коляски мотоцикла

        public Motorcycle(int _speed, int _probabilityPuncturedWheel, bool _isSidecar) : base(_speed, _probabilityPuncturedWheel)
        {
            isSidecar = _isSidecar;
        }
    }
}
