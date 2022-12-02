namespace TextCalculator.Models
{

    /// <summary>
    /// View model for the calculator, used by the view
    /// </summary>
    public class CalculatorViewModel
    {
        public string Number { get; set; }
        public string ErrorMessage { get; set; }
        public string Result { get; set; }

        public CalculatorViewModel()
        {
            ErrorMessage = String.Empty;
            Result = String.Empty;
        }
    }
}
