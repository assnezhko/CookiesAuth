using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISecurityService
    {
        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        string getMd5Hash(string input);

        // Verify a hash against a string.
        bool verifyMd5Hash(string input, string hash);
    }
}
