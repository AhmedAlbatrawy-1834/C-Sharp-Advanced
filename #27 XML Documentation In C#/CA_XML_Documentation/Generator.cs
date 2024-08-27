using System.Collections.Generic;

namespace CA_XML_Documentation
{
    /// <include file="GeneratorXML.xml" path="docs/members[@name='Generator']/Generator/*" />
    public class Generator
    {
        /// <include file="GeneratorXML.xml" path="docs/members[@name='Generator']/LastSequence/*"/>
        public static int LastSequence { get; private set; } = 1;

        /// <include file="GeneratorXML.xml" path="docs/members[@name='Generator']/GenerateId/*"/>
        public static string GenerateId(string FName, string LName, DateTime? HTime)
        {
            if (string.IsNullOrEmpty(FName))
                throw new InvalidOperationException($"{nameof(FName)} can not be null or Empty");

            if (string.IsNullOrEmpty(LName))
                throw new InvalidOperationException($"{nameof(LName)} can not be null or Empty");

            if (HTime == null)
            {
                HTime = DateTime.Now;
            }
            else
            {
                if (HTime.Value.Date < DateTime.Now.Date)
                {
                    throw new InvalidOperationException("you can not hire Employee in past");
                }
            }
            var yy = HTime.Value.ToString("yy");
            var mm = HTime.Value.ToString("MM");
            var dd = HTime.Value.ToString("dd");
            var code = $"{FName[0]}{LName[0]}-{yy}-{mm}-{dd}-{(LastSequence++).ToString().PadLeft(2, '0')}";

            return code;
        }

        public static string GeneratePassword(int Len)
        {
            const string ValidScope = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string password = string.Empty;
            while (0 < Len--)
            {
                password += (ValidScope[Random.Shared.Next(ValidScope.Length)]);
            }

            return password;
        }
    }
}
