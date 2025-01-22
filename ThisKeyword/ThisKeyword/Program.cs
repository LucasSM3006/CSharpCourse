MedicalAppointment appointment = new MedicalAppointment("Johnathan Joestar", new DateTime(2025, 4, 3));

// Overwrite entire appointment date
appointment.reschedule(new DateTime(2025, 4, 3));

// Overwrite month and day
appointment.overwriteMonthAndDay(12, 2);

appointment.reschedule(new DateTime(2025, 4, 6));

Console.ReadKey();


public class MedicalAppointment
{
    private string _patientName; 
    private DateTime _date;

    public MedicalAppointment(string patientName, DateTime date)
    {
        _patientName = patientName;
        // 'this.patientName = patientName' could also be used if I didn't follow the naming conventions here.
        _date = date;
    }

    public void reschedule(DateTime date)
    {
        _date = date;
        var printer = new MedicalAppointmentPrinter();
        printer.print(this); // Passes the own/current instance.
    }

    public void overwriteMonthAndDay(int month, int day)
    {
        _date = new DateTime(_date.Year, month, day);
    }

    public void moveByMonthsAndDays(int monthsToAdd, int daysToAdd)
    {
        _date = new DateTime(
            _date.Year,
            _date.Month + monthsToAdd,
            _date.Day + daysToAdd);
    }

    public DateTime getDate()
    {
        return _date;
    }
}

public class MedicalAppointmentPrinter
{
    public void print(MedicalAppointment medicalAppointment)
    {
        Console.WriteLine($"Appointment will take place on {medicalAppointment.getDate()}");
    }
}