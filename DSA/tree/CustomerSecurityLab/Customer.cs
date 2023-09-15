using System.Security.Cryptography;
using System.Text;

namespace CustomerSecurityLab
{
    public class Customer
    {
        private CreditCardEncryption encrypt = new CreditCardEncryption();
        private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public string Name { get; }
        public string Email { get;}
        public byte[] EncryptedCreditCard { get; }
        public string HashedPassword { get; }
        private byte[] Salt;

        public Customer(string name, string email, string CreditCard, string password)
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            this.Name = name;
            this.Email = email;
            this.EncryptedCreditCard = encrypt.EncryptAsync(CreditCard, this.Name).Result;
            this.HashedPassword = HashPassword(password);
        }
        string HashPassword(string password)
        {
            
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Salt,
                350000,
                hashAlgorithm,
                64);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, this.Salt, 350000, hashAlgorithm, 64);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(this.HashedPassword));
        }

        public string DecryptCreditCard(string password)
        {
            bool isPassword = VerifyPassword(password); // To be implemented
            if (isPassword)
            {
                return encrypt.DecryptAsync(EncryptedCreditCard, this.Name).Result;
            }
            return "wrong password, try again...";
        }
    }
}