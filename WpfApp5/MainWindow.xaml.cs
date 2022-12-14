using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HtmlWeb web = new HtmlWeb();
        string mxn2;
        string uah2;
        public MainWindow()
        {
            InitializeComponent();
            ParsMxn();
            ParsUnh();
        }


        public void ParsMxn()
        {
            var url = @"https://ru.investing.com/currencies/rub-mxn";
            var ExchangeRates = web.Load(url);

            string mxn = ExchangeRates.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div/div[2]/main/div/div[1]/div[2]/div[1]/span").First().InnerText;
            mxn2 = mxn;
            Yuyu.Items.Add("Пессо");
        }

        public void ParsUnh()
        {
            var url = @"https://ru.investing.com/currencies/rub-uah";
            var ExchangeRates = web.Load(url);

            string uah = ExchangeRates.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div/div[2]/main/div/div[1]/div[2]/div[1]/span").First().InnerText;
            uah2 = uah;
            Yuyu.Items.Add("Гривны");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Yuyu.SelectedIndex == 0)
            {
                Result.Content = "Результат: " + Convert.ToDouble(Value.Text) * Convert.ToDouble(mxn2);
            }
            else if (Yuyu.SelectedIndex == 1)
            {
                Result.Content = "Результат: " + Convert.ToDouble(Value.Text) * Convert.ToDouble(uah2);
            }

        }

    }
}
