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
    public class CustomerUpdateController : ApiController
    {
         #region Properties

            private IRepository _ads;

        #endregion

        #region Constructors

            public CustomerUpdateController([Named("AdsEntities")]IRepository db)
            {
                _ads = db;
            }

        #endregion

        /// <summary>
        /// Update all records that need to be updated.
        /// </summary>
        /// <returns>ProductInfoClass</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {

            try
            {
                var update = _ads.Query<ADS_SERIAL_TRACKING>()
                    .Where(x => x.ACK_CODE =="U")
                    .Select(x => new ProductInfoClass
                    {
                        SERIAL_NUM = x.SERIAL_NUMBER
                        , SKU = x.SKU
                        , CUSTOMER_NAME = x.CUSTOMER_NAME
                        , CUSTOMER_NUM = x.CUSTOMER_NUMBER
                        , ADDRESS_1 = x.SHIP_TO_ADDRESS1
                        , ADDRESS_2 = x.SHIP_TO_ADDRESS2
                        , ADDRESS_3 = x.SHIP_TO_ADDRESS3
                        , CITY = x.CITY
                        , STATE_PROV = x.STATE_PROVINCE
                        , POSTAL_CODE = x.POSTAL_CODE
                        , COUNTRY = x.COUNTRY
                        , SHIP_DATE = x.SHIP_DATE
                        , ORDER_NUM = x.ORDER_NUMBER
                        , CONTACT_EMAIL = x.CONTACT_EMAIL
                        , CONTACT_NAME = x.CONTACT_NAME
                    }).ToArray();
                _ads.Dispose();

                return Request.CreateResponse(HttpStatusCode.OK, update);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            
        }

        /// <summary>
        /// Update product table acknowledgeing data recived.
        /// </summary>
        /// <param name="valueObj"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]List<PostInfoClass> valueObj)
        {
            var errorList = new List<PostInfoClass>();
            foreach (var valO in valueObj)
            {
                var id = valO.SERIAL_NUMBER;
                var code = valO.ACK_CODE;
                var message = valO.ACK_MESSAGE;

                try
                {
                    var rec = _ads.Query<ADS_SERIAL_TRACKING>()
                            .Where(x => x.ACK_CODE == "U")
                            .Single(x => x.SERIAL_NUMBER == id);
                    rec.ACK_DATE = DateTime.Now;
                    rec.ACK_MESSAGE = message;
                    rec.ACK_CODE = code;
                    _ads.Save();

                }
                catch (Exception ex)
                {
                    ADS_ERROR_LOG log = new ADS_ERROR_LOG();
                    log.REQUEST = "Customer Update";
                    log.TYPE = "Post";
                    log.SERIAL = id;
                    log.MESSAGE = ex.Message;
                    log.TIME_DATE = DateTime.Now;

                    _ads.Add<ADS_ERROR_LOG>(log);
                    _ads.Save();

                    var error = new PostInfoClass { SERIAL_NUMBER = id, ACK_MESSAGE = ex.Message };
                    errorList.Add(error);

                }
            }
            _ads.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK, errorList);


        }
    }
}