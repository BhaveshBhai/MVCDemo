using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetracWebApp.Models
{
    public class AreaModel
    {
        public List<Area> LoadAreas()
        {
            List<Area> lstAreas = new List<Area>();
            try
            {
                using (SafetracEntities db = new SafetracEntities())
                {
                    lstAreas = db.GetAllAreas().Select(x=> new Area{id= x.id, area_name= x.area_name}).ToList();
                    return lstAreas;
                }
            }
            catch (Exception e)
            {
                return lstAreas;
            }

        }
    }
}