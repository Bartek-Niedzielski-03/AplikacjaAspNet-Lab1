namespace Laboratorium1.Models;

public enum Operator
{
    Unknown,
    Add,
    Sub,
    Mul,
    Div
}

public class Calculator
{
    public Operator? Operator { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }

    public string Op
    {
        get
        {
            switch (Operator)
            {
                case Models.Operator.Add:
                    return "+";
                case Models.Operator.Sub:
                    return "-";
                case Models.Operator.Mul:
                    return "*";
                case Models.Operator.Div:
                    return "/";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Operator != null && X != null && Y != null;
    }

    public double Calculate()
    {
        switch (Operator)
        {
            case Models.Operator.Add:
                return X!.Value + Y!.Value;
            case Models.Operator.Sub:
                return X!.Value - Y!.Value;
            case Models.Operator.Mul:
                return X!.Value * Y!.Value;
            case Models.Operator.Div:
                return X!.Value / Y!.Value;
            default:
                return double.NaN;
        }
    }
}