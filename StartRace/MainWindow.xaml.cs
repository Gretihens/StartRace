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
            List<Vehicle> vehicles = new List<Vehicle>();
        }

        private void bc_Add(object sender, RoutedEventArgs e)
        {

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

        public virtual string GetStatus()
        {
            return "ЭЭЭ меня тут нет!";
        }
    }

    public class Truck : Vehicle
    {
        public int CargoWeight { get; }                     //вес груза

        public Truck(int _speed, int _probabilityPuncturedWheel, int _cargoWeight) : base (_speed, _probabilityPuncturedWheel)
        {
            CargoWeight = _cargoWeight;
        }

        public override string GetStatus()
        {
            return $"Грузовик, Скорость: {Speed}\n" +
                $"Вероятность прокола колеса {ProbabilityPuncturedWheel}\n" +
                $"Вес груза: {CargoWeight}";
        }
    }

    public class Car : Vehicle
    {
        public int NumberPassengers { get; }                //количество пассажиров

        public Car(int _speed, int _probabilityPuncturedWheel, int _numberPassengers) : base(_speed, _probabilityPuncturedWheel)
        {
            NumberPassengers = _numberPassengers;
        }

        public override string GetStatus()
        {
            return $"Легковой, Скорость: {Speed}\n" +
                $"Вероятность прокола колеса {ProbabilityPuncturedWheel}\n" +
                $"Количество пассажиров: {NumberPassengers}";
        }
    }

    public class Motorcycle : Vehicle
    {
        public bool isSidecar { get; }                      //наличие коляски мотоцикла

        public Motorcycle(int _speed, int _probabilityPuncturedWheel, bool _isSidecar) : base(_speed, _probabilityPuncturedWheel)
        {
            isSidecar = _isSidecar;
        }

        public override string GetStatus()
        {
            return $"Мотоцикл, Скорость: {Speed}\n" +
                $"Вероятность прокола колеса {ProbabilityPuncturedWheel}\n" +
                $"{(isSidecar ? "Мотоцикл с коляской" : "Мотоцикл без коляски")}";
        }
    }
}
