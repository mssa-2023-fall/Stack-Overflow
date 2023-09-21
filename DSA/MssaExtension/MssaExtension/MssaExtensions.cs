using System.Security.Cryptography;


namespace MssaExtension
{
    public enum StringFormat
    {
        Base64,
        Hex
    }


    public static class MssaExtensions
    {
        public static string GetSHAString(this FileInfo _file, StringFormat format)
        {
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(_file.OpenRead());
                return format switch
                {
                    StringFormat.Base64 => Convert.ToBase64String(fileHash),
                    StringFormat.Hex => Convert.ToHexString(fileHash),
                    _ => Convert.ToBase64String(fileHash)
                };

            }

        }

        public static T Median<T>(this IEnumerable<T> _intArr)
        {
            //How to constraint T tot that of numbers
            var sorted = _intArr.OrderBy(n => n).ToList();
            //Pick out the middle term
            var middleItem = sorted.Count / 2;
            return sorted[middleItem];
        }
    }
}


