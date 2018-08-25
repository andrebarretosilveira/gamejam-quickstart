using System;
using System.Runtime.Serialization;

[Serializable]
internal class NullPoolObjectException : Exception
{
    public NullPoolObjectException()
    {
    }

    public NullPoolObjectException(string message) : base(message)
    {
    }

    public NullPoolObjectException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NullPoolObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}