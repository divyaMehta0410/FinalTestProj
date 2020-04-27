using DataAccessLayer.Repository;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class CampServices
    {
        private readonly CampsRepository campsRepository;
        public CampServices()
        {
            campsRepository = new CampsRepository();
        }
        public IEnumerable<Camps> GetAllCamps()
        {
            var camps = campsRepository.getAll().ToList();
            return camps;
        }
        public Camps GetCamp(Guid Id)
        {
            return campsRepository.GetCamp(Id);
        }
        public bool AddCamp(Camps camp)
        {
            var result = campsRepository.Add(camp);
            return result > 0;
        }
        public bool UpdateCamp(Camps camp)
        {
            var result = campsRepository.Update(camp);
            return result > 0;
        }
        public bool DeleteCamp(Guid id)
        {
            var result = campsRepository.Delete(id);
            return result > 0;
        }
        public IEnumerable<Camps> GetAvailableCamps()
        {
            return campsRepository.FindAvailabilty();
        }
        public void SetBooked(Guid campId, bool value)
        {
            campsRepository.SetBooked(campId, value);
        }
        public IEnumerable<Camps> SearchCampsBetween(DateTime checkinDate, DateTime chekoutDate, int capacity)
        {
            return  campsRepository.GetCampsBetween(checkinDate, chekoutDate, capacity);
        }
    }
}