using System;
using System.Collections.Generic;
using SeriesRegistration.app.Interfaces;

namespace SeriesRegistration.app
{
    public class SeriesRepository : IRepository<Series>
    {

        private List<Series> listSeries = new List<Series>();
        public void Att(int id, Series entity)
        {
            listSeries[id] = entity;
        }

        public void Exclude(int id)
        {
            listSeries[id].Exclude();
        }

        public void Insert(Series entity)
        {
            listSeries.Add(entity);
        }

        public List<Series> List()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public Series ReturnPerId(int id)
        {
            return listSeries[id];
        }
    }
}