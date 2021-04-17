using Microsoft.Win32;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using swf = System.Windows.Forms;


namespace RoboChatWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string BackgroundImagePath { get; set; }
        public string ProfPictureImagePath { get; set; }
        public string[] prop = new string[2] { "Change prof picture", "Change name of prof" };
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in prop)
            {
                cb.Items.Add(item);
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDesign message = new MessageDesign();
            if (MessageSendtxtbox.Text != "")
            {

                message.MessageTake = MessageSendtxtbox.Text;
                message.TimeTxtBlck = DateTime.Now.ToShortTimeString();
             
                ListBox.Items.Add(message);
                MessageSendtxtbox.Clear();
            }
            else if (MessageSendtxtbox.Text == "")
            {
                MessageBox.Show("I can't send empty message", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                {
                    BackgroundImagePath = openFileDialog.FileName;
                    ImageBrush imageBrush = new ImageBrush();
                    Uri imageUri = new Uri(BackgroundImagePath, UriKind.Relative);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    imageBrush.ImageSource = imageBitmap;
                    ListBox.Background = imageBrush;
                }
            }
        }
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            string val = String.Empty;
            if (cbx.SelectedValue == null)
                val = cbx.SelectionBoxItem.ToString();
            else
                val = cbx.SelectedValue.ToString();
            if (val== "Change prof picture")
            {
                //ImageUserCntrl
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                    {
                        ProfPictureImagePath = openFileDialog.FileName;
                        ImageBrush imageBrush = new ImageBrush();
                        Uri imageUri = new Uri(ProfPictureImagePath, UriKind.Relative);
                        BitmapImage imageBitmap = new BitmapImage(imageUri);
                        imageBrush.ImageSource = imageBitmap;

                        ImageUserCntrl.ImageSource = imageBrush.ImageSource;

                    }
                }
            }
                else if (val == "Change name of prof")
                {

                   
                    ChangeNameTxtBox.Visibility=Visibility.Visible;
                    OkBtn.Visibility = Visibility.Visible;
                    CacelBtn.Visibility = Visibility.Visible;
               
                
                }
                

        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeNameTxtBox.Text!=""&& ChangeNameTxtBox.Text.Length<=7)
            {

            ProfName.Text = ChangeNameTxtBox.Text;
            ChangeNameTxtBox.Text = "";
           

            ChangeNameTxtBox.Visibility = Visibility.Hidden;
            OkBtn.Visibility = Visibility.Hidden;
            CacelBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Something went wrong!","Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }

        }

        private void CacelBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeNameTxtBox.Visibility = Visibility.Hidden;
            OkBtn.Visibility = Visibility.Hidden;
            CacelBtn.Visibility = Visibility.Hidden;
        }
    }
}
