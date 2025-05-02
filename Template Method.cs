//Szenario: E-Mails senden – Ablauf ist gleich inhalt anders

abstract class EmailNotification
{
    public void Send()
    {
        ConnectToServer();     // immer gleich
        string content = ComposeMessage(); // unterschiedlich
        SendEmail(content);    // immer gleich
        Disconnect();          // immer gleich
    }

    private void ConnectToServer()
    {
        Console.WriteLine("Verbinde mit SMTP-Server...");
    }

    protected abstract string ComposeMessage(); // Muss in Subklasse definiert werden

    private void SendEmail(string message)
    {
        Console.WriteLine($"Sende E-Mail mit Inhalt: {message}");
    }

    private void Disconnect()
    {
        Console.WriteLine("Verbindung getrennt.");
    }
}
//Subklassen: Unterschiedliche E-Mail-Typen
class InvoiceEmail : EmailNotification
{
    protected override string ComposeMessage()
    {
        return "Ihre Rechnung für März 2025 ist beigelegt.";
    }
}

class PasswordResetEmail : EmailNotification
{
    protected override string ComposeMessage()
    {
        return "Hier ist Ihr Link zum Zurücksetzen Ihres Passworts.";
    }
}
