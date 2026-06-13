using System;

namespace miniapiaspnetcore.Domain.Exceptions
{
    public class DuplicateRfcException : Exception
    {
        public DuplicateRfcException(string rfc) : base($"RFC duplicado: {rfc}") { }
    }
}