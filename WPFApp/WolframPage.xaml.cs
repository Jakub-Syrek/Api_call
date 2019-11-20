using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using WolframAlphaNet;
using WolframAlphaNet.Objects;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for WolframPage.xaml
    /// </summary>
    public partial class WolframPage : Page
    {
        public WolframPage()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void loadWolfram_Click(object sender, RoutedEventArgs e)
        {
            if (MathQuerry.Text != null && MathQuerry.Text != "")
            {
               var results = await WolframProcessor.LoadWolfram($"{MathQuerry.Text}");            

               if (results != null)
               {
                    if (ImgPanel.Children.Count > 0)
                    {
                        ImgPanel.Children.Clear();
                    }                   

                    var conv = new ImageSourceConverter();
                    foreach (Pod pod in results.Pods)
                    {
                        WrapPanel wrapPanel = new WrapPanel();
                        
                        if (pod.SubPods != null)
                        {
                           foreach (SubPod subPod in pod.SubPods)
                           {
                                if (string.IsNullOrWhiteSpace(subPod.Title)==false || string.IsNullOrWhiteSpace(subPod.Plaintext) == false)
                                {
                                    TextBlock textBlock = new TextBlock();
                                    textBlock.Margin = new Thickness(10, 10, 10, 0);
                                    if (!(string.IsNullOrWhiteSpace(subPod.Title)))
                                    {
                                        textBlock.Text = $"{subPod.Title}=>{Environment.NewLine}";                                        
                                    }
                                    if (!(string.IsNullOrWhiteSpace(subPod.Plaintext)))
                                    {
                                        textBlock.Text = $"{subPod.Plaintext}=>"; 
                                    }
                                    wrapPanel.Children.Add(textBlock);
                                }

                                string urlImg = subPod.Image.Src;
                                if (string.IsNullOrWhiteSpace(urlImg) == false)
                                {
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(urlImg);
                                    bitmap.EndInit();
                                    System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                                    image.Source = bitmap;
                                    
                                        image.Width = 300;
                                        image.Height = 30;
                                    
                                    wrapPanel.Children.Add(image);
                                }
                           }
                        }
                        wrapPanel.Background = System.Windows.Media.Brushes.Azure;
                        wrapPanel.Orientation = Orientation.Horizontal;
                        //wrapPanel.Width = wrapPanel.ItemWidth;
                        wrapPanel.HorizontalAlignment = HorizontalAlignment.Center;
                        wrapPanel.VerticalAlignment = VerticalAlignment.Top;
                        ImgPanel.Children.Add(wrapPanel);
                    }                   
               }
            }
        }        
    }
}
//if (string.IsNullOrWhiteSpace(pod.Title) == false)
//{
//    TextBlock textBlock = new TextBlock();
//    textBlock.Margin = new Thickness(10, 100, 10, 0);
//    textBlock.Text = $"pod.Title:{pod.Title}=>";
//    wrapPanel.Children.Add(textBlock);
//}                        