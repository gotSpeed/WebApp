using System;


namespace WebApp.DataAccess.Misc.Exceptions {

    public class RowNotFoundException : Exception {

        public RowNotFoundException() : base() { }
        public RowNotFoundException(string message) : base(message) { }

    }

}
