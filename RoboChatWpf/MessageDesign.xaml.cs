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

namespace RoboChatWpf
{
    /// <summary>
    /// Interaction logic for MessageDesign.xaml
    /// </summary>
    public partial class MessageDesign : UserControl
    {

        public MessageDesign()
        {
            InitializeComponent();
        }
        public string MessageTake
        {
            get
            {

                return MessageTxtBlck.Text.ToString();
            }
            set
            {
                if (value != "")
                {

                    MessageTxtBlck.Text = value;
                }
                else
                {
                    MessageBox.Show("Input something");
                }
            }
        }
        public string TimeTxtBlck
        {
            get { return TimePick.Text.ToString(); }
            set
            {
                TimePick.Text = value;
            }
        }
       // public Image MessagePctr { get { return YourPicturePctr; } set { YourPicturePctr.Source = value.Source; } }


    }
}
