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
        string name;
        string search = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        //static string LoadPage(string url)
        //{
        //    var result = "";
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    var response = (HttpWebResponse)request.GetResponse();

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var receiveStream = response.GetResponseStream();
        //        if (receiveStream != null)
        //        {
        //            StreamReader readStream;
        //            if (response.CharacterSet == null)
        //                readStream = new StreamReader(receiveStream);
        //            else
        //                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
        //            result = readStream.ReadToEnd();
        //            readStream.Close();
        //        }
        //        response.Close();
        //    }
        //    return result;

        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    string pageContent = LoadPage(url: @"https://ru.investing.com/currencies/rub-mxn");
        //    var document = new HtmlDocument();
        //    document.LoadHtml(pageContent);

        //    HtmlNodeCollection Mxn = document.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div/div[2]/main/div/div[1]/div[2]/div[1]/span");
        //    mxn2 = Mxn.First().InnerText;

        //    string pageContent2 = LoadPage(url: @"https://ru.investing.com/currencies/rub-uah");
        //    var document2 = new HtmlDocument();
        //    document2.LoadHtml(pageContent);

        //    HtmlNodeCollection Uah = document.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div/div[2]/main/div/div[1]/div[2]/div[1]/span");
        //    uah2 = Uah.First().InnerText;

        //    Valute.Items.Add("Гривны");
        //    Valute.Items.Add("Песо");
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Valute.SelectedIndex == 0)
        //    {
        //        Result.Content = "Результат: " + Convert.ToDouble(Count.Text) * Convert.ToDouble(uah2);
        //    }
        //    else if (Valute.SelectedIndex == 1)
        //    {
        //        Result.Content = "Результат: " + Convert.ToDouble(Count.Text) * Convert.ToDouble(mxn2);
        //    }
        //}



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = Convert.ToDouble(Value.Text) * Convert.ToDouble(mxn2);
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                search = Poisk.Text;
                var url = @"https://ru.investing.com/currencies/" + search;
                var ExchangeRates = web.Load(url);

                string mxn = ExchangeRates.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div/div[2]/main/div/div[1]/div[2]/div[1]/span").First().InnerText;
                mxn2 = mxn;
                name = ExchangeRates.DocumentNode.SelectNodes("/html/body/div[1]/div/div/div/div[2]/main/div/div[1]/div[1]/h1").First().InnerText;
                Valuta.Content = name;
            }
            catch 
            {
                MessageBox.Show("Введите правильную валюту");
            }
            
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }
    }
}

