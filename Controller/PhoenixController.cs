using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SouthNests.Phoenix.Framework;
using SouthNests.PhoenixMobile.Translators;
using SouthNests.PhoenixMobile.Model;


namespace WebApplication1.Controller
{
    public class PhoenixController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
        [HttpPost]
        public HttpResponseMessage SignupMobileUser(MobileUserSignup item)
        {
            AuthenticateUser au = PhoenixMobileUserTranslator.SignupMobileUser(item);

            var response = Request.CreateResponse <AuthenticateUser> (HttpStatusCode.Created, au);

            return response;
        }
        [HttpPost]
        public HttpResponseMessage LoginMobileUser(MobileUserSignup item)
        {
            if (item == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            AuthenticateUser au = PhoenixMobileUserTranslator.LoginMobileUser(item);

            var response = Request.CreateResponse<AuthenticateUser>(HttpStatusCode.Created, au);

            return response;
        }

        [HttpPost]
        public List<EmployeeListModel> GetEmployeeData(EmployeeId item)
        {
            return PhoenixMobileEmployeeTranslator.ListEmployee("");
        }
        [HttpPost]
        public List<EmployeeSearchModel> GetSearchedData(EmployeeSearch item)
        {
            return PhoenixMobileEmployeeTranslator.ListSearching(item);
        }


        [HttpPost]
        public int AddEmployeeData(EmployeeAddModel item)
        {
           return PhoenixMobileEmployeeTranslator.AddEmployeeData(item);
        }

        [HttpPost]
        public int AddPlacesData(PlaceAddModel item)
        {
            return PhoenixMobilePlacesTranslator.AddPlaceData(item);
        }

        [HttpPost]
        public List<PlacesListModel> GetPlacesData(PlacesId item)
        {
            return PhoenixMobilePlacesTranslator.ListPlaces("");
        }

        [HttpPost]
        public int EditEmployeeData(EmployeeEditModel item)
        {
            return PhoenixMobileEmployeeTranslator.EditEmployeeData(item);
        }

        
    }
}
