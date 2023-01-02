using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UrlConverter;

public class ClipboardManager
{
    /// <summary>
    /// Sets the clipboard text for Mac OS X.
    /// </summary>
    /// <param name="text">Text to copy to clipboard</param>
    public static void SetClipboardTextMacOS(string text)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            throw new PlatformNotSupportedException("This method is only supported on Mac OS X.");
        
        // Create a process that will execute the pbcopy command
        Process process = new Process();
        process.StartInfo.FileName = "pbcopy";
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();

        // Write the text to the process's standard input
        process.StandardInput.Write(text);
        process.StandardInput.Close();
        Console.WriteLine("Text copied to clipboard. (Method: pbcopy - Mac OS X)");
    }

    /// <summary>
    /// Sets the clipboard text for Windows.
    /// </summary>
    /// <param name="text">Text to copy to clipboard</param>
    public static void SetClipboardTextWindows(string text)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new PlatformNotSupportedException("This method is only supported on Windows");
/*
        // Allocate memory on the global heap for the text
        IntPtr hGlobal = Marshal.StringToHGlobalUni(text);

        // Set the clipboard data
        SetClipboardData(13, hGlobal);

        // Free the global memory
        Marshal.FreeHGlobal(hGlobal);*/

        Console.Error.WriteLine("This functionality currently only works on macOS due to missing clipboard implementation.");
        Console.Error.WriteLine("Instead, the text is stored in the clipboard as a file in the /tmp directory");
        string path = FileManager.WriteTextToTmpFile(text);
        Console.WriteLine("Text written to path. (Method: Write to file - Windows)");
        Console.WriteLine("Path: " + path);
    }
    
    /*[DllImport("user32.dll")]
    static extern bool SetClipboardData(uint uFormat, IntPtr hMem);*/
}