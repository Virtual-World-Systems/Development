
namespace github
{
    /// <summary>
    /// Summary description for Authentication
    /// </summary>
    public class Authentication
    {
        //static readonly string password = "t4084.4085";
        static readonly string token = "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";

        public static string String
        {
            get { return _string ?? Initialize(out _string); }
        }
        static string _string;
        static string Initialize(out string str)
        {
            string pair = github.User.Name + ":" + token;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(pair);
            string base64 = System.Convert.ToBase64String(bytes);
            return str = "Basic " + base64;
        }
    }
}