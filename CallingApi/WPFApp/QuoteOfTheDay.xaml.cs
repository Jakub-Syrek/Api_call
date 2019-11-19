using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
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
            //async void loadQuote_Click(object sender, RoutedEventArgs e)
            //{
            //    var quoteModel = await QuoteProcessor.LoadQuote();

            //    Quote.Text = quoteModel.Quote;
            //    Author.Text = quoteModel.Author;
            //    Author.Text = quoteModel.Author;
            //}    

        }        
        //async Task loadQuote_Click1(object sender, RoutedEventArgs e)
        //{
        //    var response = await QuoteProcessor.LoadQuote();
        //    var quoteModel = response.quotes.ToList();
        //    Quote.Text = quoteModel.First(x => x.quote != null).quote;
        //    Author.Text = quoteModel.First(x => x.author != null).author;
        //    Category.Text = quoteModel.First(x => x.category != null).category;
        //}

        private async Task LoadQuote_Click2(object sender, RoutedEventArgs e)
        {
            var response = await QuoteProcessor.LoadQuote();
            var quoteModel = response.quote;
            //Quote.Text = quoteModel.First(x => x.quote != null).quote;
            //Author.Text = quoteModel.First(x => x.author != null).author;
            //Category.Text = quoteModel.First(x => x.category != null).category;
        }

        //private async Task loadQuote_ClickAsync(object sender, RoutedEventArgs e)
        //{
        //    Contents<QuoteModel> response = await QuoteProcessor.LoadQuote();
        //    //response.Wait();
        //    var x = response.quotes;
        //  //  var quoteModel = response.quotes.ToList();
        //    //Quote.Text = quoteModel.First(x => x.quote != null).quote;
        //   // Author.Text = quoteModel.First(x => x.author != null).author;
        //    //Category.Text = quoteModel.First(x => x.category != null).category;
        //}

        private async void loadQuote_Click(object sender, RoutedEventArgs e)
        {
            Quote response = await QuoteProcessor.LoadQuote();
            
            //response.Wait();
            //var x = quoteModel;
        }
    }

   


}
