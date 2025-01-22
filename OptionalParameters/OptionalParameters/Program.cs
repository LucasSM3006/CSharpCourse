MedicalAppointment appointment = new MedicalAppointment("Johnathan Joestar", new DateTime(2025, 4, 3));
MedicalAppointment appointment2 = new MedicalAppointment("Rosanna");
MedicalAppointment appointment3 = new MedicalAppointment();


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
        _date = date;
    }

    public MedicalAppointment(string patientName = "Unknown", int daysFromNow = 7) // Obs. Optional parameters need to be the last ones. 'daysFromNow, patientName' would not work
        // Also, in case of ambiguity, aka, another constructor with just 'patientName' on it, the one with no optionals is always picked.
    {
        _patientName=patientName;
        _date = DateTime.Now.AddDays(daysFromNow);
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