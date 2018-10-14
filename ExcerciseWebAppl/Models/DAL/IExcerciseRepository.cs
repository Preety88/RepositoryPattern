using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseWebAppl.Models.DAL
{
    interface IExcerciseRepository: IDisposable
    {
        IEnumerable<Excercise> GetExcercises();

        Excercise GetExcerciseByID(int exceciseID);

        void InsertExcercise(Excercise excercise);

        void DeleteExcecise(int excerciseID);

        void UpdateExcercise(Excercise excercise);

        void Save();
    }
}
