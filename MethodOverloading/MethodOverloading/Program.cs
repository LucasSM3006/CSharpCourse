MedicalAppointment appointment = new MedicalAppointment("Johnathan Joestar", new DateTime(2025, 4, 3));

// Overwrite entire appointment date
appointment.reschedule(new DateTime(2025, 4, 3));

// Overwrite month and day
appointment.overwriteMonthAndDay(12, 2);


public class MedicalAppointment
{
    private string _patientName;
    private DateTime _date;

    public MedicalAppointment(string patientName, DateTime date)
    {
        _patientName = patientName;
        _date = date;
    }

    public void reschedule(DateTime date)
    {
        _date = date;
    }

    public void overwriteMonthAndDay(int month, int day)
    {
        _date = new DateTime(_date.Year, month, day);
    }
}