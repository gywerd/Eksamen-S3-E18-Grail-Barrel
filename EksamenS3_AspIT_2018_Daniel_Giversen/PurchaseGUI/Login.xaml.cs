using PurchaseBizz;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PurchaseGUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        BizzDbAccess BDA;
        Grid MainGrid;
        Grid MenuGrid;
        ObservableCollection<Credential> users = new ObservableCollection<Credential>();
        //GUIMockUpDb GMUD = new GUIMockUpDb();

        public Login(BizzDbAccess bda, Grid mainGrid, Grid menuGrid)
        {
            InitializeComponent();
            this.BDA = bda;
            this.MainGrid = mainGrid;
            this.MenuGrid = menuGrid;
        }

        private void User_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (user.Text.Length > 20)
            {
                MessageBox.Show("Brugernavn må maks være 20 tegn", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                user.Text = user.Text.Substring(0, 20);
            }
        }

        private void Pw_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool error = false;
            foreach (char item in pw.Text)
            {
                if (item.ToString() == "")
                {
                    int ShortPassWord = int.Parse(pw.Text);
                    pw.Text = ShortPassWord.ToString();
                    error = true;
                }
            }

            if (pw.Text.Length > 20)
            {
                pw.Text = user.Text.Substring(0, 20);
                error = true;
            }
            if (error)
            {
                MessageBox.Show("Password må maks være 20 tegn, og må ikke indeholde mellemrum", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BDA.CheckCredentials(user.Text, pw.Text))
            {
                UcPurchase UcPurchase = new UcPurchase();
                GrainDeal UcGrainDeal = new GrainDeal();
                MenuGrid.Children.Clear();
                MainGrid.Children.Clear();
                MenuGrid.Children.Add(UcPurchase);
                MainGrid.Children.Add(UcGrainDeal);
            }
            else
            {
                MessageBox.Show("Der er fejl i brugernavn eller password", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
