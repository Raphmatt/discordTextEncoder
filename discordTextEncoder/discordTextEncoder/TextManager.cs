using System.Text;

namespace UrlConverter;

public class TextManager
{
    public const string MessageHideString = "||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​||||​|| _ _ _ _ _ _ ";
    
    /// <summary>
    /// Converts a given url to an encoded form of the url
    ///
    /// Important: the http:// or https:// part of the url is not encoded and will be normally returned
    /// </summary>
    /// <param name="url"></param>
    /// <returns>encoded url </returns>
    public static string ConvertToUnreadableUrl(string url)
    {
        // Remove the "https://" part of the URL
        url = url.Substring(8);

        // Create a new StringBuilder to store the converted URL
        StringBuilder sb = new StringBuilder();

        // Iterate through each character in the URL
        foreach (char c in url)
        {
            // If the character is a letter, add the ASCII value of the character as a hexadecimal string
            if (char.IsLetter(c))
            {
                sb.Append("%" + ((int)c).ToString("X"));
            }
            // Otherwise, add the character as is
            else
            {
                sb.Append(c);
            }
        }
        
        // Return the converted URL as a string and reAdd the "https://" part
        return "https://" + sb.ToString();
    }
}