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

namespace InteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
		Controller controller = Controller.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
			Counter();
			DisableBottoms();
        }
		
		private void Counter()
		{
			PersonCount.Content = "Person Count " + controller.PersonCount;
			IndexCount.Content = "Index " + controller.PersonIndex;
		}
		private void DisableBottoms()
		{
			if (controller.PersonCount == 0)
			{
				FirstName.IsEnabled = false;
				LastName.IsEnabled = false;
				Age.IsEnabled = false;
				TelePhoneNo.IsEnabled = false;
				DeletePerson.IsEnabled = false;
				
			}
			if (controller.PersonCount < 2)
			{
				Up.IsEnabled = false;
				Down.IsEnabled = false;
			}
		}
		
		private void EnableBottoms()
		{

			FirstName.IsEnabled = true;
			LastName.IsEnabled = true;
			Age.IsEnabled = true;
			TelePhoneNo.IsEnabled = true;
			DeletePerson.IsEnabled = true;

			if (controller.PersonCount >= 2)
			{
				Up.IsEnabled = true;
				Down.IsEnabled = true;
			}
			
		}
	
		private void ClearContent()
		{
			if(controller.PersonCount == 0)
			{
				FirstName.Clear();
				LastName.Clear();
				Age.Clear();
				TelePhoneNo.Clear();
			}
			else
			{
				FirstName.Text = controller.CurrentPerson.FirstName;
				LastName.Text = controller.CurrentPerson.LastName;
				Age.Text = controller.CurrentPerson.Age.ToString();
				TelePhoneNo.Text = controller.CurrentPerson.TelephoneNo;
			}
		}

		private void NewPerson_Click(object sender, RoutedEventArgs e)
		{
			controller.AddPerson();
			Counter();
			ClearContent();
			EnableBottoms();
			
		}

		private void DeletePerson_Click(object sender, RoutedEventArgs e)
		{
			controller.DeletePerson();
			Counter();
			ClearContent();
			DisableBottoms();
						
		}

		private void Up_Click(object sender, RoutedEventArgs e)
		{
			controller.NextPerson();
			Counter();
			ClearContent();
		}

		private void Down_Click(object sender, RoutedEventArgs e)
		{
			controller.PrevPerson();
			Counter();
			ClearContent();
		}

		private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controller.PersonCount != 0)
			{
				controller.CurrentPerson.FirstName = FirstName.Text;
			}
		}

		private void LastName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controller.PersonCount != 0)
			{
				controller.CurrentPerson.LastName = LastName.Text;
			}
		}

		private void Age_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controller.PersonCount != 0)
			{
				int.TryParse(Age.Text, out int age);
				controller.CurrentPerson.Age = age;
			}
		}

		private void TelePhoneNo_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (controller.PersonCount != 0)
			{
				controller.CurrentPerson.FirstName = FirstName.Text;
			}
		}
	}
}
