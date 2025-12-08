using System;

namespace Laboratorium1.Models;

public class Birth
{
    public string? Name { get; set; }
    public DateTime? Date { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name)
               && Date != null
               && Date < DateTime.Today;
    }

    public int Age()
    {
        if (Date == null)
        {
            return 0;
        }

        var today = DateTime.Today;
        int age = today.Year - Date.Value.Year;

        if (Date.Value.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}