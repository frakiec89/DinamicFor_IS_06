// track
using System.Windows;
using System.Windows.Controls;


namespace WpfApp14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int countStack = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var elemenet = GetElementStart();
            myStack.Children.Add(elemenet);

            var elment2 = GetElement();
            myStack.Children.Add(elment2);

            var elemenet3 = GetElementFinish();
            myStack.Children.Add(elemenet3);
        }

     

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var elemenet = GetElement();
            myStack.Children.Insert(myStack.Children.Count-1, elemenet);
        }

        private UIElement GetElementStart()
        {
            countStack++;

            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            stack.Name = "stack" + countStack.ToString();
            stack.Margin = new Thickness(5);

            TextBox textBox = new TextBox();
            textBox.Margin = new Thickness(5);
            textBox.MinWidth = 100;
            textBox.Name = "tb" + countStack;
            stack.Children.Add(textBox);

            return stack;
        }


        private UIElement GetElement()
        {
            countStack++;
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            stack.Name = "stack" + countStack.ToString();
            stack.Margin = new Thickness(5);

            Label label = new Label();
            label.Margin = new Thickness(5);
            label.FontSize = 50;
            label.Content = "+" ;

            TextBox textBox = new TextBox();
            textBox.Margin = new Thickness(5);
            textBox.MinWidth = 100;
            textBox.Name = "tb" + countStack;


            stack.Children.Add(label);
            stack.Children.Add(textBox);
            return stack;
        }

        private UIElement GetElementFinish()
        {
            countStack++;
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            stack.Name = "stack" + countStack.ToString();
            stack.Margin = new Thickness(5);

            Label label = new Label();
            label.Margin = new Thickness(5);
            label.FontSize = 50;
            label.Content = "=";

            TextBox textBox = new TextBox();
            textBox.Margin = new Thickness(5);
            textBox.MinWidth = 100;
            textBox.Name = "tb_otvet" ;

            stack.Children.Add(label);
            stack.Children.Add(textBox);
            return stack;
        }

        private void Button_Click_Sum(object sender, RoutedEventArgs e)
        {
            double otevet = 0;

            foreach (var item in myStack.Children)
            {
                StackPanel stac = item as StackPanel;
                if (stac != null)
                {
                    foreach (var ui in stac.Children)
                    {
                        TextBox textBox = ui as TextBox;

                        if (textBox != null && textBox.Name != "tb_otvet")
                        {
                            try
                            {
                                otevet += Convert.ToDouble(textBox.Text);
                            }
                            catch
                            {
                                otevet += 0;
                                textBox.Text = "Error";
                            }
                           
                        }

                        if (textBox != null && textBox.Name == "tb_otvet")
                        {
                            textBox.Text = otevet.ToString();
                        }
                    }

                }
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            myStack.Children.Clear();
            MainWindow_Loaded(sender, e);
        }
    }
}