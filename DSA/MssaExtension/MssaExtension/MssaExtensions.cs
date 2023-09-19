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

        public static float Median(this IEnumerable<int> _intArr)
        {
            var sorted = _intArr.OrderBy(n => n).ToList();
            var middleItem = sorted.Count / 2;
            if (sorted.Count % 2 == 1) return sorted[middleItem];
            return ((float)sorted[middleItem] + (float)sorted[middleItem + 1]) / 2;
        }
    }
}


