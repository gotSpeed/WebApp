#nullable enable


using System;
using System.Runtime.Serialization;


namespace WebApp.DataAccess.Misc.Exceptions {

	public class DbEntityNotFoundException : Exception {

		public DbEntityNotFoundException() : base() { }

		public DbEntityNotFoundException(string? message) : base(message) { }

		public DbEntityNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

		protected DbEntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

	}

}
