using System.Windows;
namespace GUICalc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        OperationSelect.ItemsSource = new List<string>()
        {
            "Сложение",
            "Вычитание",
            "Умножение",
            "Деление"
        };
       
    }
    
    private void CalculateResult(object sender, RoutedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(FirstParam.Text) || String.IsNullOrWhiteSpace(SecondParam.Text))
        {
            MessageBox.Show("Пустое поле для ввода", "Ошибка");
            return;
        }
        var checkFirstParamParse = double.TryParse(FirstParam.Text, out double firstParam);
        var checkSecondParamParse = double.TryParse(SecondParam.Text, out double secondParam);
        if (!(checkFirstParamParse & checkSecondParamParse))
        {
            MessageBox.Show("Ошибка в данных", "Ошибка");
            return;
        }
        Result.Text = Calc(firstParam, secondParam).ToString();
    }

    private double Calc(double firstParam, double secondParam)
    {
        switch (OperationSelect.SelectedIndex)
        {
            case 0:
                return firstParam + secondParam;
            case 1:
                return firstParam - secondParam;
            case 2:
                return firstParam * secondParam;
            case 3:
                return firstParam / secondParam;
            default:
                return Double.NaN; // заглушка - без нее компилятор ругается на отсутствие return-а
        }
    }
}
        
   
