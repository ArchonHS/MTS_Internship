class Program
{



    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch { }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {

        //1
        //Process.GetCurrentProcess().Kill();

        //2
        //Environment.Exit(-1);

        //3
        /*[DllImport("user32.dll")]
		static extern bool EndTask(IntPtr hWnd, bool fShutDown, bool fForce);
		EndTask(Process.GetCurrentProcess().Handle, true, true);*/

        //4
        /*[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);
		TerminateProcess(Process.GetCurrentProcess().Handle, 0);*/

        //5 Recursive call
        //FailProcess();

    }
}
