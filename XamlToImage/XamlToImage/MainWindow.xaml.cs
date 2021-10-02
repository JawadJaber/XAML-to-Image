using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlToImage
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void export_images_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var canvas_as_string = XamlWriter.Save(this);
              //  var modified_canvas_as_string = canvas_as_string.Replace("MainCanvas", "MainCanvas1");
              // var new_main_window = (Window)XamlReader.Parse(modified_canvas_as_string);

                var args = new BitmapMakerArgs
                {
                    Element = MainCanvas,
                    FileName = "image1.png",
                    CreateBlackVersion = true,
                    ImageSizes = new Size[] {  },
                };

                BitmapMaker.Start(args);

                MainCanvas.RenderTransform = new ScaleTransform();
                MainCanvas.UpdateLayout();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "XAML to Image");
                //Close();
            }
        }
    }


}
