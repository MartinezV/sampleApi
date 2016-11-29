using AdsApi.Api.Classes;
using AdsApi.Api.Models;
using AdsApi.Api.Schema;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Description;

namespace AdsApi.Api.Controllers
{
    public class CustomerController : ApiController
    {
        #region Properties

            private IRepository _location;

        #endregion

        #region Constructors

            public CustomerController([Named("LocationEntities")]IRepository db)
            {
                _location = db;
            }

        #endregion

        /// <summary>
        /// Retrieve customer information data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {

            try
            {
                var dealer = _location.Query<ADS_DEALER_LOCATIONS>()
                    .Select(x => new CustomerInfoClass
                    {
                        ID = x.ID
                        , DEALER_NAME = x.DEALER_NAME
                        , ASSOCIATED_CUSTOMER_ID = x.ASSOCIATED_CUSTOMER_ID
                        , ADDRESS_1 = x.ADDRESS_1
                        , ADDRESS_2 = x.ADDRESS_2
                        , ADDRESS_3 = x.ADDRESS_3
                        , CITY = x.CITY
                        , STATE = x.STATE
                        , POSTAL_CODE = x.POSTAL_CODE
                        , EMAIL = x.EMAIL
                        , URL = x.URL
                        , PHONE = x.PHONE
                        , FAX = x.FAX
                        , CREATED_DATE = x.CREATED_DATE
                        , MODIFIED_DATE = x.MODIFIED_DATE
                        , FACEBOOK_URL = x.FACEBOOK_URL
                        , PREMIUM_DEALER = x.PREMIUM_DEALER
                        , ADS = x.ADS
                    }).ToArray();
                _location.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK,dealer);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            
        }

        /// <summary>
        /// Retrieve search results from customer table using state and city.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetStateCity(string state, string city)
        {
            try
            {
                var dealerInfo = _location.Query<ADS_DEALER_LOCATIONS>()
                    .Where(x => x.STATE == state.ToUpper() && x.CITY == city.ToUpper())
                    .Select(x => new CustomerInfoClass
                    {
                        ID = x.ID
                        , DEALER_NAME = x.DEALER_NAME
                        , ASSOCIATED_CUSTOMER_ID = x.ASSOCIATED_CUSTOMER_ID
                        , ADDRESS_1 = x.ADDRESS_1
                        , ADDRESS_2 = x.ADDRESS_2
                        , ADDRESS_3 = x.ADDRESS_3
                        , CITY = x.CITY
                        , STATE = x.STATE
                        , POSTAL_CODE = x.POSTAL_CODE
                        , EMAIL = x.EMAIL
                        , URL = x.URL
                        , PHONE = x.PHONE
                        , FAX = x.FAX
                        , CREATED_DATE = x.CREATED_DATE
                        , MODIFIED_DATE = x.MODIFIED_DATE
                        , FACEBOOK_URL = x.FACEBOOK_URL
                        , PREMIUM_DEALER = x.PREMIUM_DEALER
                        , ADS = x.ADS
                    }).ToArray();
                _location.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK, dealerInfo);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent); throw;
            }
            
        }

        /// <summary>
        /// Retrieve customer information using name. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetName(string name)
        {
            try
            {
                var dealerInfo = _location.Query<ADS_DEALER_LOCATIONS>()
                    .Where(x => x.DEALER_NAME.Contains(name.ToUpper()))
                    .Select(x => new CustomerInfoClass
                    {
                        ID = x.ID
                        , DEALER_NAME = x.DEALER_NAME
                        , ASSOCIATED_CUSTOMER_ID = x.ASSOCIATED_CUSTOMER_ID
                        , ADDRESS_1 = x.ADDRESS_1
                        , ADDRESS_2 = x.ADDRESS_2
                        , ADDRESS_3 = x.ADDRESS_3
                        , CITY = x.CITY
                        , STATE = x.STATE
                        , POSTAL_CODE = x.POSTAL_CODE
                        , EMAIL = x.EMAIL
                        , URL = x.URL
                        , PHONE = x.PHONE
                        , FAX = x.FAX
                        , CREATED_DATE = x.CREATED_DATE
                        , MODIFIED_DATE = x.MODIFIED_DATE
                        , FACEBOOK_URL = x.FACEBOOK_URL
                        , PREMIUM_DEALER = x.PREMIUM_DEALER
                        , ADS = x.ADS
                    }).ToArray();
                _location.Dispose();
                
                return Request.CreateResponse(HttpStatusCode.OK, dealerInfo);
            }
            catch (Exception)
            {
                
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            
        }

    }
}