using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace StartRace
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Task tMain;
        List<Task> tVehicle = new List<Task>();
        List<Vehicle> vehicles = new List<Vehicle>();
        int distance;

        public MainWindow()
        {
            InitializeComponent();
            cbType.Items.Add("Truck");
            cbType.Items.Add("Car");
            cbType.Items.Add("Motorcycle");
        }

        private void bc_Add(object sender, RoutedEventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    vehicles.Add(new Truck(int.Parse(tbSpeed.Text), int.Parse(tbProbability.Text), int.Parse(tbSpecific.Text)));
                    break;
                case 1:
                    vehicles.Add(new Car(int.Parse(tbSpeed.Text), int.Parse(tbProbability.Text), int.Parse(tbSpecific.Text)));
                    break;
                case 2:
                    vehicles.Add(new Motorcycle(int.Parse(tbSpeed.Text), int.Parse(tbProbability.Text), tbSpecific.Text == "да" ? true : false));
                    break;
                default:
                    break;
            }
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbType.SelectedIndex)
            {
                case 0:
                    lSpecific.Content = "Вес груза кг";
                    break;
                case 1:
                    lSpecific.Content = "Количество пассажиров";
                    break;
                case 2:
                    lSpecific.Content = "Наличие коляски да/нет";
                    break;
                default:
                    break;
            }
        }

        private void bc_Start(object sender, RoutedEventArgs e)
        {
            distance = int.Parse(tbDistance.Text);
            tMain = Task.Run(() => Race());
        }

        private void Race()
        {
            foreach (var item in vehicles)
            {
                tVehicle.Add(Task.Run(() => Drive(item, distance)));
            }
        }

        private void Drive(Vehicle _v, int _distance)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                tbOut.AppendText(_v.GetStatus());
            });

            for (int i = 0; i < _distance; i++)
            {
                if (Punctured(_v.ProbabilityPuncturedWheel))
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        tbOut.AppendText($"{_v.GetType().Name} прокол колеса!\n");
                    });
                    Thread.Sleep(5000);
                }
                Thread.Sleep(1000);
                _v.Distance += _v.Speed;
            }
        }

        private bool Punctured(int chance)
        {
            return new Random().NextDouble() < chance;
        }
    }

    public abstract class Vehicle
    {
        public int Speed { get; }                           //скорость метров в секунду
        public int ProbabilityPuncturedWheel { get; }       //вероятность прокола колеса
        public int Distance { get; set; }                   //пройденное расстояние

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
            return $"Truck, Скорость: {Speed}\n" +
                $"Вероятность прокола колеса {ProbabilityPuncturedWheel}\n" +
                $"Вес груза: {CargoWeight}\n";
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
            return $"Car, Скорость: {Speed}\n" +
                $"Вероятность прокола колеса {ProbabilityPuncturedWheel}\n" +
                $"Количество пассажиров: {NumberPassengers}\n";
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
            return $"Motorcycle, Скорость: {Speed}\n" +
                $"Вероятность прокола колеса {ProbabilityPuncturedWheel}\n" +
                $"{(isSidecar ? "Мотоцикл с коляской" : "Мотоцикл без коляски")}\n";
        }
    }
}
