using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSecurityLab
{
    public interface ICrypto
    {
        Task<byte[]> EncryptAsync(string text, string passphrase);
        Task<string> DecryptAsync(byte[] encrypted, string passphrase);

    }
}
