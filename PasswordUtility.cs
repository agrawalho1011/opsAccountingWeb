namespace OpsAccounting
{
    public class PasswordUtility
    {
        public string DecodeBase64(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            var valueBytes = System.Convert.FromBase64String(value);
            return System.Text.Encoding.UTF8.GetString(valueBytes);
        }

        public string Base64Encode(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
