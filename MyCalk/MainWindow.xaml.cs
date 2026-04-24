using System;
using System.Windows;
using System.Windows.Controls;
using MyLibraryCalk;

namespace MyCalk
{
	public partial class MainWindow : Window
	{
		private CalcLibrary _calculator;

		public MainWindow()
		{
			InitializeComponent();
			_calculator = new CalcLibrary();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			string content = button.Content.ToString();

			if (Display.Text == "0" && content != ".")
				Display.Text = content;
			else
				Display.Text += content;
		}

		private void Operation_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			string operation = button.Content.ToString();

			string lastChar = "";
			if (Display.Text.Length > 0)
			{
				lastChar = Display.Text[Display.Text.Length - 1].ToString();
			}

			if (lastChar != "+" && lastChar != "-" && lastChar != "*" &&
				lastChar != "/" && lastChar != "^")
			{
				Display.Text += operation;
			}
			else
			{
				Display.Text = Display.Text.Substring(0, Display.Text.Length - 1) + operation;
			}
		}

		private void Equals_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				double result = _calculator.Calculate(Display.Text);
				Display.Text = result.ToString();
			}
			catch (DivideByZeroException)
			{
				Display.Text = "Ошибка";
			}
			catch (Exception)
			{
				Display.Text = "Ошибка";
			}
		}

		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			Display.Text = "0";
		}
	}
}