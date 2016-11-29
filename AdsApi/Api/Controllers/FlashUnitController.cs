using AdsApi.Api.Classes;
using AdsApi.Api.Models;
using AdsApi.Api.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Web;
using System.Diagnostics;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;
using Ninject;





namespace AdsApi.Api.Controllers
{
    public class FlashUnitController : ApiController
    {
        #region Properties

        readonly IRepository _ads;

        #endregion

        #region Constructors

        public FlashUnitController([Named("AdsEntities")]IRepository db)
        {
            _ads = db;
        }

        #endregion

        /// <summary>
        /// Add flash information to database. 
        /// </summary>
        /// <param name="valueObj"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put([FromBody] IEnumerable<FlashInfoClass> valueObj)
        {
            foreach (var x in valueObj)
            {
                ADS_FLASHED_UNITS flash = new ADS_FLASHED_UNITS();
                flash.SERIAL_NUMBER = x.SERIAL_NUMBER;
                flash.CUSTOMER_NUMBER = x.CUSTOMER_NUMBER;
                flash.FLASH_DATE = x.FLASH_DATE;
                flash.VEHICLE_MAKE = x.VEHICLE_MAKE;
                flash.VEHICLE_MODEL = x.VEHICLE_MODEL;
                flash.VEHICLE_YEAR = x.VEHICLE_YEAR;
                flash.USER_FLASH_UNIT = x.USER_FLASH_UNIT;
                flash.CREATION_DATE = DateTime.Now;
                try
                {
                    _ads.Add<ADS_FLASHED_UNITS>(flash);
                    _ads.Save();

                    int id = Convert.ToInt32(flash.FLASH_ID);

                    if (x.UPGRADE.Count > 0)
                    {
                        PutUpgrade(id, x.UPGRADE);
                    }

                }
                catch (Exception ex)
                {

                    Debug.WriteLine(ex);
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            _ads.Save();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected void PutUpgrade(int id, IList<UpgradesInfoClass> upgrade)
        {
            foreach (var x in upgrade)
            {
                ADS_UPGRADES flashUpgrade = new ADS_UPGRADES();
                flashUpgrade.UPGRADE = x.TYPE;
                flashUpgrade.FLASH_ID = id;

                try
                {
                    _ads.Add<ADS_UPGRADES>(flashUpgrade);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Upgrade: " + ex);
                }
                
            }
        }

    }
}
