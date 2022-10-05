using FluentAssertions;

namespace ExpenseReports.Test;

public class ExpenseReportShould
{
    private readonly StringWriter _stringWriter = new StringWriter();
    private readonly ExpenseReport _expenseReport = new ExpenseReport();
    public ExpenseReportShould()
    {
        Console.SetOut(_stringWriter);
    }

    [Fact]
    public void Print_Empty_List()
    {
        _expenseReport.PrintReport(new List<Expense>(), DateTime.Parse("2022-05-01"));

        Assert.Equal("Expenses 01/05/2022 0:00:00\r\nMeal expenses: 0\r\nTotal expenses: 0\r\n", _stringWriter.ToString());
    }
    [Fact]

    public void Print_Below_Min()
    {
        Expense minExpense = new Expense();
        minExpense.Amount = 1;
        minExpense.Type = ExpenseType.BREAKFAST;
        _expenseReport.PrintReport(new List<Expense> { minExpense }, DateTime.Parse("2022-10-05"));
        var output = _stringWriter.ToString();
        _stringWriter.ToString().Should().StartWith("Expenses").And.EndWith("Expenses 05/10/2022 0:00:00\r\nBreakfast\t1\t \r\nMeal expenses: 1\r\nTotal expenses: 1\r\n");

        //output.Should().Be("Expenses 05/10/2022 0:00:00\r\nBreakfast\t1\t \r\nMeal expenses: 1\r\nTotal expenses: 1\r\n");

        //Assert.Equal("", _stringWriter.ToString);
    }
}