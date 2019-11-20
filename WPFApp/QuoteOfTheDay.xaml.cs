using DemoLibrary;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for QuoteOfTheDay.xaml
    /// </summary>
    public partial class QuoteOfTheDay : Page
    {
        public QuoteOfTheDay()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }               
        
        private async void loadQuote_Click(object sender, RoutedEventArgs e)
        {
            Quotes response = await QuoteProcessor.LoadQuote();

            Quote.Text = response.contents.quotes.First(x => x.quote != null).quote;
            Author.Text = response.contents.quotes.First(x => x.author != null).author;
            Category.Text = response.contents.quotes.First(x => x.category != null).category;            
        }
    }

   


}
