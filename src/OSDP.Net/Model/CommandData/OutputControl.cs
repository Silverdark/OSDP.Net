using System.Collections.Generic;
using OSDP.Net.Messages;

namespace OSDP.Net.Model.CommandData
{
    /// <summary>
    /// Contains data to control a single output on a PD.
    /// </summary>
    public class OutputControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputControl"/> class.
        /// </summary>
        /// <param name="outputNumber">The output number.</param>
        /// <param name="outputControlCode">The output control code.</param>
        /// <param name="timer">The timer in units of 100ms.</param>
        public OutputControl(byte outputNumber, OutputControlCode outputControlCode, ushort timer)
        {
            OutputNumber = outputNumber;
            OutputControlCode = outputControlCode;
            Timer = timer;
        }

        /// <summary>
        /// Gets the output number.
        /// </summary>
        public byte OutputNumber { get; }

        /// <summary>
        /// Gets the output control code.
        /// </summary>
        public OutputControlCode OutputControlCode { get; }

        /// <summary>
        /// Gets the timer in units of 100ms.
        /// </summary>
        public ushort Timer { get; }

        internal IEnumerable<byte> BuildData()
        {
            var timerBytes = Message.ConvertShortToBytes(Timer);
            
            return new[] {OutputNumber, (byte) OutputControlCode, timerBytes[0], timerBytes[1]};
        }
    }
}