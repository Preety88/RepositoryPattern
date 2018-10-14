using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseWebAppl.Models.DAL
{
    public class ExcerciseRepository : IExcerciseRepository, IDisposable
    {
        private readonly HarpreetEntities _entities;

        public ExcerciseRepository(HarpreetEntities entities)
        {
            this._entities = entities;
        }

        public void DeleteExcecise(int excerciseID)
        {
            Excercise excercise = _entities.Excercises.Find(excerciseID);
            _entities.Excercises.Remove(excercise);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Excercise GetExcerciseByID(int exceciseID)
        {
            return _entities.Excercises.Find(exceciseID);
        }

        public IEnumerable<Excercise> GetExcercises()
        {
            return _entities.Excercises.ToList().OrderBy(x => x.ExcerciseName);
        }

        public void InsertExcercise(Excercise excercise)
        {
            _entities.Excercises.Add(excercise);
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void UpdateExcercise(Excercise excercise)
        {
            _entities.Entry(excercise).State = System.Data.Entity.EntityState.Modified;
        }
    }
}