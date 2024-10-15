using static MoreAdvancedCalculator.Controllers.CalculatorController;

public class Calculator
{
    public Operator? Op { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public String OpString
    {
        get
        {
            switch (Op)
            {
                case Operator.Add:
                    return "+";
                case Operator.Sub:
                    return "-";
                case Operator.Mul:
                    return "*";
                case Operator.Div:
                    return "/";
                case Operator.Pow:
                    return "^";
                case Operator.Sin:
                    return "Sin";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Op != null && X != null && Y != null;
    }

    public double Calculate() {
            double? result = double.NaN;

            switch(Op)
            {
                case Operator.Add:
                    result = X + Y;
                    break;
                case Operator.Sub:
                    result = X - Y;
                    break;
                case Operator.Mul:
                    result = X * Y;
                    break;
                case Operator.Div:
                    if(Y == 0)
                    {
                        break;
                    }
                    result = X / Y;
                    break;
                case Operator.Pow:
                    result = Math.Pow(X.Value,Y.Value);
                    break;
                case Operator.Sin:
                    result = Math.Sin(X.Value * Math.PI / 180);
                    result = (double)Math.Round((decimal)result * 1000000) / 1000000;
                    break;                                      
            }

            return (double)result;
    }
}