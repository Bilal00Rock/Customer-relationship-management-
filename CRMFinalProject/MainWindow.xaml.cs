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
using System.Windows.Forms;
using System.Windows.Media.Effects;

namespace CRMFinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        void OpenWinForm(Form f)
        {
            Window g = this.FindName("Main") as Window;
            BlurBitmapEffect blurbitmapEffect = new BlurBitmapEffect();
            blurbitmapEffect.Radius = 20;

            g.BitmapEffect = blurbitmapEffect;
            f.ShowDialog();
            blurbitmapEffect.Radius = 0;
            g.BitmapEffect = blurbitmapEffect;
        }

        

        private void WrapPanel_MouseLeftButtonDown_Customer(object sender, MouseButtonEventArgs e)
        {
            CustomersForm f = new CustomersForm();
            OpenWinForm(f);
        }
        private void WrapPanel_MouseLeftButtonDown_Product(object sender, MouseButtonEventArgs e)
        {
            ProductForm f = new ProductForm();
            OpenWinForm(f);
        }

        private void WrapPanel_MouseLeftButtonDown_Invoice(object sender, MouseButtonEventArgs e)
        {
            InvoiceForm f = new InvoiceForm();
            OpenWinForm (f);
        }

        private void WrapPanel_MouseLeftButtonDown_Activity(object sender, MouseButtonEventArgs e)
        {
            ActivityForm f = new ActivityForm();
            OpenWinForm(f);
        }

        private void WrapPanel_MouseLeftButtonDown_Reminder(object sender, MouseButtonEventArgs e)
        {
            ReminderForm f = new ReminderForm();
            OpenWinForm(f);
        }

        private void WrapPanel_MouseLeftButtonDown_SmsPanel(object sender, MouseButtonEventArgs e)
        {
            SmsPanelForm f = new SmsPanelForm();
            OpenWinForm(f);
        }
        private void Image_MouseLeftButtonDown_Power(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
