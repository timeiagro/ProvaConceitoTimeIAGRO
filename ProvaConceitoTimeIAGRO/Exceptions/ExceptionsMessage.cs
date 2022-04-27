using System;

namespace ProvaConceitoTimeIAGRO.Exceptions
{
    /// <summary>
    /// Exceptions Message
    /// </summary>
    public class ExceptionsMessage : ApplicationException
    {
        /// <summary>
        /// Construtor Exceptions Message
        /// </summary>
        public ExceptionsMessage() { }

        /// <summary>
        /// Construtor Exception Message
        /// </summary>
        /// <param name="message">string</param>
        public ExceptionsMessage(string message)
            : base(message) { }

        /// <summary>
        /// Construtor Exception Message
        /// </summary>
        /// <param name="message">sring</param>
        /// <param name="inner">Exception</param>
        public ExceptionsMessage(string message, Exception inner)
            : base(message, inner) { }
    }
}