using WebApp.Domain.Core;


namespace WebApp.Domain.Interfaces {

    public interface IPetitionUserRepository : IRepository<PetitionUser> {

        public bool CheckIfUserPutSign(params object[] pkeys);

    }

}
