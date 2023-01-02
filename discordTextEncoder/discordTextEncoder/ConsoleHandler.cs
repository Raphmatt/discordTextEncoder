using System.Runtime.InteropServices;

namespace UrlConverter;

public class ConsoleHandler
{
    public static void ConsoleStart()
    {
        ConsoleKeyInfo command;
        do
        {
            MenuSelection();
            
            command = Console.ReadKey();
            switch (command.Key)
            {
                case ConsoleKey.D1:
                    ConvertUrl();
                    break;
                case ConsoleKey.D2:
                    ConvertUrlAndMakeInvisible();
                    break;
                case ConsoleKey.D3:
                    ConvertUrlAndMakeInvisibleWithMessage();
                    break;
            }

        } while (command.Key != ConsoleKey.Q);

        Environment.Exit(0);
    }
    public static void MenuSelection()
    {
        Console.Clear();
        Console.WriteLine(@"-------------------------
Please select an option from the menu below:
1. Convert a URL to an encoded URL (Ex. a discord video link is not downloadable. At least not in discord itself)
2. Convert a URL to an encoded URL and make it invincible (you can add other text)
3. Convert a URL to an encoded URL and make it invincible with a message
q: Exit
Enter your selection: ");
    }
    private static void ConvertUrl()
    {
        Console.Clear();
        Console.WriteLine("Enter the URL you want to convert: ");
        string url = Console.ReadLine();
        string encodedurl = TextManager.ConvertToUnreadableUrl(url);
        Console.WriteLine("The encoded URL is: " + encodedurl);
        ReturnResult(encodedurl);
    }
    private static void ConvertUrlAndMakeInvisible()
    {
        Console.Clear();
        Console.WriteLine("Enter the URL you want to convert: ");
        string url = Console.ReadLine();
        string encodedurl = TextManager.ConvertToUnreadableUrl(url);

        string result = TextManager.MessageHideString + encodedurl;
        
        ReturnResult(result);
    } 
    private static void ConvertUrlAndMakeInvisibleWithMessage()
    {
        Console.Clear();
        Console.WriteLine("Enter the URL you want to convert: ");
        string url = Console.ReadLine();
        string encodedurl = TextManager.ConvertToUnreadableUrl(url);
        
        Console.WriteLine("Enter the text you want to display: ");
        string text = Console.ReadLine();

        string result = text + TextManager.MessageHideString + encodedurl;
        
        ReturnResult(result);
    }
    private static void ReturnResult(string text)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            ClipboardManager.SetClipboardTextMacOS(text);
        }
        else
        {
            ClipboardManager.SetClipboardTextWindows(text);
        }
        Console.ReadKey();
    }

}