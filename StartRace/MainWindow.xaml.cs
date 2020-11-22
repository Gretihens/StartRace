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
    }

    public class Truck : Vehicle
    {
        public int CargoWeight { get; }                     //вес груза
    }

    public class Car : Vehicle
    {
        public int NumberPassengers { get; }                //количество пассажиров
    }

    public class Motorcycle : Vehicle
    {
        public bool isSidecar { get; }                      //наличие коляски мотоцикла
    }
}
