using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Security.Claims;

using WebApp.DataAccess.Misc.Exceptions;
using WebApp.Domain.Core;
using WebApp.Domain.Interfaces;


namespace WebApp.Controllers {

    public class PublicationsController : Controller {

        protected readonly IPollRepository _pollRepository;
        protected readonly IPetitionRepository _petitionRepository;
        protected readonly IPetitionUserRepository _petitionUserRepository;


        public PublicationsController(IPollRepository pollRepository,
                                      IPetitionRepository petitionRepository,
                                      IPetitionUserRepository petitionUserRepository) : base() {

            _pollRepository = pollRepository;
            _petitionRepository = petitionRepository;
            _petitionUserRepository = petitionUserRepository;
        }

        [Route("~/Publications")]
        public IActionResult Publications() {
            ViewBag.Polls = _pollRepository.GetAll();
            ViewBag.Petitions = _petitionRepository.GetAll();

            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();
        }

        [HttpGet]
        public IActionResult New() {
            return View("CreatePetition");
        }

        #region Petition
        public IActionResult Petition(int id) {

            try {
                Petition model = _petitionRepository.Get(id);

                ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.IsAlreadySigned = _petitionUserRepository.CheckIfUserPutSign(
                    ViewBag.UserId == null ? null : int.Parse(ViewBag.UserId),
                    id
                );

                ViewBag.NextGoalPercentage  = Math.Ceiling(model.VotersAmount * 100.0 / model.NextGoal);
                ViewBag.TotalGoalPercentage = Math.Ceiling(model.VotersAmount * 100.0 / model.TotalGoal);

                return View(model);
            }
            catch (RowNotFoundException exception) {
                //add
                return new NotFoundResult();
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult PetitionVote(int id) {

            try {
                _petitionUserRepository.Create(
                    new PetitionUser() {
                        UserId      = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                        PetitionId  = id
                    }
                );

                Petition model = _petitionRepository.Get(id);
                model.VotersAmount++;
                _petitionRepository.Update(model, model.Id);

                return RedirectToActionPermanent("Petition", new { id = id });
            }
            catch (DbUpdateException exception) {
                // send to error page
                return RedirectToActionPermanent("Petition", new { id = id });
            }
            catch (RowNotFoundException exception) {
                //add
                return new NotFoundResult();
            }
        }
        #endregion

        #region Poll
        public IActionResult Poll(int id) {

            try {
                Poll model = _pollRepository.Get(id);

                return View();
            }
            catch (RowNotFoundException exception) {
                //add
                return new NotFoundResult();
            }
        }
        #endregion

    }

}
