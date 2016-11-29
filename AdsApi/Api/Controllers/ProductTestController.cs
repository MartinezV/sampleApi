using AdsApi.Api.Classes;
using AdsApi.Api.Models;
using AdsApi.Api.Schema;
using Ninject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;
namespace AdsApi.Api.Controllers
{
    public class ProductTestController : ApiController
    {
        public class UpdateProduct
        {
            public decimal SERIAL_NUM_ID { get; set; }
        }

        #region Properties

            private IRepository _ads;

        #endregion

        #region Constructors

            public ProductTestController([Named("AdsEntities")]IRepository db)
            {
                _ads = db;
            }

        #endregion

        
        // POST api/<controller>
        /// <summary>
        /// FOR TESTING PUROPOSES ONLY.Removes Acknowledge Date, Message, and Code.
        /// </summary>
        /// <param name="valueObj"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]List<PostInfoClass> valueObj)
        {

            foreach (var valO in valueObj)
            {
                var id = valO.SERIAL_NUMBER;

                try
                {
                    var rec = _ads.Query<ADS_SERIAL_TRACKING>()
                            .Single(x => x.SERIAL_NUMBER == id);
                    rec.ACK_DATE = null;
                    rec.ACK_MESSAGE = "";
                    rec.ACK_CODE = "";
                    _ads.Save();

                }
                catch (Exception)
                {

                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            _ads.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);


        }

        /// <summary>
        /// FOR TESTING ONLY. Add new record to customer table
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        public HttpResponseMessage Put([FromBody]List<ProductInfoClass> data) {


            foreach (var x in data)
            {
                ADS_SERIAL_TRACKING track = new ADS_SERIAL_TRACKING();
                track.SHIP_TO_ADDRESS1 = x.ADDRESS_1;
                track.SHIP_TO_ADDRESS2 = x.ADDRESS_2;
                track.SHIP_TO_ADDRESS2 = x.ADDRESS_3;
                track.CITY = x.CITY;
                track.CONTACT_EMAIL = x.CONTACT_EMAIL;
                track.CONTACT_NAME = x.CONTACT_NAME;
                track.COUNTRY = x.COUNTRY;
                track.CUSTOMER_NAME = x.CUSTOMER_NAME;
                track.CUSTOMER_NUMBER = x.CUSTOMER_NUM;
                track.ORDER_NUMBER = x.ORDER_NUM;
                track.POSTAL_CODE = x.POSTAL_CODE;
                track.SERIAL_NUMBER = x.SERIAL_NUM;
                track.SHIP_DATE = x.SHIP_DATE;
                track.SKU = x.SKU;
                track.STATE_PROVINCE = x.STATE_PROV;

                try
                {
                    _ads.Add<ADS_SERIAL_TRACKING>(track);
                    _ads.Save();
                }
                catch (Exception)
                {

                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
               
            }
            _ads.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK);
        
        }

    }
}