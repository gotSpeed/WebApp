using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using WebApp.DataAccess.DbContexts;
using WebApp.DataAccess.Misc.Exceptions;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;


namespace WebApp.DataAccess.Repositories {

    public class PetitionRepository : IPetitionRepository {

        private readonly CustomDbContext _context;


        public PetitionRepository(CustomDbContext context) {
            _context = context;
        }

        public Petition Get(params object[] pkeys) {
            return _context.Petitions.Find(pkeys) ??
                   throw new RowNotFoundException($"Cannot extract data: no row with id = {pkeys}");
        }

        public IEnumerable<Petition> GetMostPopular() {
            var PetitionsList = from Petition Petition in _context.Petitions
                                orderby Petition.VotersAmount descending
                                select Petition;

            return PetitionsList.Include(petition => petition.Author)
                                .ToList();
        }

        public IEnumerable<Petition> GetAll() {
            return _context.Petitions.ToList();
        }

        public void Create(Petition newInstance) {
            try {
                _context.Petitions.Add(newInstance);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception) {
                //add log here

                _context.Petitions.Remove(newInstance);

                throw exception;
            }
        }

        public void Delete(params object[] pkeys) {
            Petition PetitionToDelete = null;

            try {
                PetitionToDelete = _context.Petitions.Find(pkeys) ??
                                    throw new RowNotFoundException($"Cannot delete data: no row with pkeys = {pkeys}");

                _context.Petitions.Remove(PetitionToDelete);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception) {
                //add log here

                _context.Petitions.Add(PetitionToDelete);

                throw exception;
            }
        }

        public void Update(Petition newData, params object[] pkeys) {
            try {
                Petition updatedInstance = _context.Petitions.Find(pkeys) ??
                                           throw new RowNotFoundException($"Cannot update data: no row with pkeys = {pkeys}");

                updatedInstance.Header              =  newData.Header ??
                                                       (newData.Header.Length != 0 ? newData.Header : updatedInstance.Header);
                updatedInstance.ShortDescription    =  newData.ShortDescription ??
                                                       (newData.ShortDescription.Length != 0 ?
                                                        newData.ShortDescription : updatedInstance.ShortDescription);
                updatedInstance.Description         =  newData.Description ??
                                                       (newData.Description.Length != 0 ?
                                                        newData.Description : updatedInstance.Description);
                updatedInstance.ExpirationDate      =  newData.ExpirationDate;
                updatedInstance.TotalGoal           =  newData.TotalGoal <= updatedInstance.TotalGoal ?
                                                       updatedInstance.TotalGoal : newData.TotalGoal;
                updatedInstance.VotersAmount        += newData.VotersAmount - updatedInstance.VotersAmount == 1 ? 1 : 0;

                CheckExpirationDate(updatedInstance);

                _context.Update(updatedInstance);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception) {
                //add log here

                throw exception;
            }
        }

        private void CheckExpirationDate(Petition petition) {
            DateTime now = DateTime.UtcNow;
            petition.IsClosed = petition.ExpirationDate >= now ? true : false;
        }

        public void Dispose() {
            try {
                _context.SaveChanges();
            }
            catch (DbUpdateException exception) {
                //add log here

                throw exception;
            }

            //add code
        }

    }

}
