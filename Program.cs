using System;
using System.Runtime.InteropServices;

class Program
{
    const int WM_CLOSE = 0x0010;
    const int WM_SETTEXT = 0x000C;
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    public static extern IntPtr FindWindow(string className, string windowName);
    public static extern int SendMessage(IntPtr hWnd, int message, IntPtr wParam, string lParam);
    public static extern bool MessageBeep(uint uType);
    
    
    [DllImport("kernel32.dll")]
    public static extern bool Beep(int frequency, int duration);

    static void ShowInfo()
    {
        MessageBox(IntPtr.Zero, "Alex Untilov", "Name", 0);
        MessageBox(IntPtr.Zero, "16", "Age", 0);
        MessageBox(IntPtr.Zero, "Oasis", "Fav. band", 0);
    }

    static void FWindow()
    {
        Console.WriteLine("Window name:");
        string str = Console.ReadLine();
        
        IntPtr finder = FindWindow(null, str);
        if (finder != IntPtr.Zero)
        {
            Console.WriteLine("1 - New Title, 2 - Delete");
            int ans = Convert.ToInt32(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("Enter new Title");
                string newTitle = Console.ReadLine();
                SendMessage(finder, WM_SETTEXT, IntPtr.Zero, newTitle);
            }
            else if (ans == 2)
            {
                SendMessage(finder, WM_CLOSE, IntPtr.Zero, null);
            }
        }
        else Console.WriteLine("Not found");
    }

    static void Sound()
    {
        Beep(400, 200);
        MessageBeep(0xFFFFFFFF);
        Task.Delay(1000).Wait();
    }
    
    static void Main()
    {
        ShowInfo();
        FWindow();
        Sound();
    }
}