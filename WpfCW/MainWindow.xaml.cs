using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfCW
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

    [ValueConversion(typeof(string), typeof(DateTime))]
    public class DateConverter: IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dt=new DateTime();
            if (value[0].ToString().Length == 0 || value[1].ToString().Length == 0 || value[2].ToString().Length == 0||value[2].ToString().Length<4||System.Convert.ToInt32(value[0].ToString())<0 || System.Convert.ToInt32(value[0].ToString()) > 31 || System.Convert.ToInt32(value[1].ToString()) < 0 || System.Convert.ToInt32(value[1].ToString()) > 12 || System.Convert.ToInt32(value[2].ToString()) < 0)
                return DateTime.Now;
            string s = ((System.Convert.ToInt32(value[0].ToString()) > 9) ? value[0].ToString() : $"0{value[0].ToString()}") + "." + ((System.Convert.ToInt32(value[1].ToString()) > 9) ? value[1].ToString() : $"0{value[1].ToString()}") + "." + value[2].ToString();
            if (DateTime.TryParse(s, out dt))
                return dt;
            else return DateTime.Now;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { ((DateTime)value).Day.ToString(), ((DateTime)value).Month.ToString(), ((DateTime)value).Year.ToString() };
        }
    }
}
